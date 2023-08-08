namespace _Project_CheatSheet.Features.Resources.Services
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Category.Models;
    using Common.Exceptions;
    using Common.Pagination;
    using Common.UserService.Interfaces;
    using Constants.GlobalConstants.Category;
    using Constants.GlobalConstants.Resource;
    using Enums;
    using Infrastructure.Data.SQL.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Net;

    public class ResourceService : IResourceService
    {
        private const byte ResourcesPerPage = 12;
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public ResourceService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task<string> AddResources(ResourceAddModel resourceModel)
        {
            if (resourceModel == null)
            {
                throw new ServiceException(ResourceMessages.SuchModelDoesNotExist);
            }

            var isNull = resourceModel
                .GetType()
                .GetProperties()
                .Any(p => p.GetValue(resourceModel) == null);

            if (isNull || resourceModel.CategoryIds.Count == 0)
            {
                throw new ServiceException(ResourceMessages.OnUnsuccessfulResourceAdd);
            }

            var userId = currentUserService.GetUserId();

            var sanitizedContent = WebUtility.HtmlDecode(resourceModel.Content);

            var resource = new Resource
            {
                Content = sanitizedContent,
                Title = resourceModel.Title,
                ImageUrl = resourceModel.ImageUrl,
                UserId = userId
            };

            var categories = await context.Categories
                .Where(c => resourceModel.CategoryIds.Contains(c.Id))
                .ToArrayAsync();

            if (categories.Length == 0)
            {
                throw new ServiceException(CategoryMessages.NoCategoriesSelected);
            }

            await context.Resources.AddRangeAsync(resource);
            await context.SaveChangesAsync();
            foreach (var category in categories)
            {
                var categoryResource = new CategoryResource
                {
                    CategoryId = category.Id,
                    ResourceId = resource.Id
                };
                await context.CategoriesResources.AddAsync(categoryResource);
                await context.SaveChangesAsync();
            }

            return ResourceMessages.OnSuccessfulResourceAdd;
        }

        public async Task<IEnumerable<ResourceModel>> GetMyResources()
        {
            var userId = currentUserService.GetUserId();


            var testResource = await context.Resources.ToArrayAsync();

            var seeResources = await context.Resources
                .Where(res => res.UserId.ToLower() == userId.ToLower())
                .ToArrayAsync();;

            IEnumerable<ResourceModel> resources = await context.Resources
                .AsNoTracking()
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .Include(res => res.Comments)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

        public async Task<ResourceCollectionModel> GetPublicResources(int pageNumber, ResourceQueryModel query)
        {
            var userId = currentUserService.GetUserId();

            var resourceModels = context.Resources.AsQueryable();

            var resourceModelsTesting = await context.Resources.AsQueryable().ToArrayAsync();


            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var wildcard = $"%{query.Search.ToLower()}%";

                resourceModels = resourceModels
                    .Where(i => EF.Functions.Like(i.Title.ToLower(), wildcard));
            }

            if (!string.IsNullOrWhiteSpace(query.Category) && query.Sort.ToString() != "None")
            {
                resourceModels =
                    resourceModels.Where(r => r.CategoryResources.Any(cr => cr.Category.Name == query.Category));
            }

            if (query.Sort != null && query.Sort.ToString() != "None")
            {
                resourceModels = query.Sort switch
                {
                    ResourceSorting.MostLiked => resourceModels.OrderByDescending(r => r.ResourceLikes.Count),
                    ResourceSorting.LeastLiked => resourceModels.OrderBy(r => r.ResourceLikes.Count),
                    ResourceSorting.MostCommented => resourceModels.OrderByDescending(r => r.Comments.Count),
                    ResourceSorting.LeastCommented => resourceModels.OrderBy(r => r.Comments.Count),
                    ResourceSorting.LargestContent => resourceModels.OrderByDescending(r => r.Content.Length),
                    ResourceSorting.SmallestContent => resourceModels.OrderBy(r => r.Content.Length)
                };
            }

            var mappedResources =
                resourceModels.Where(r => r.IsPublic == true || r.UserId == userId)
                    .ProjectTo<ResourceModel>(mapper.ConfigurationProvider);

            var paginatedModels = await Pagination<ResourceModel>.CreateAsync(mappedResources, pageNumber);

            var filteredResources = new ResourceCollectionModel
            {
                Resources = paginatedModels,
                TotalPageCount = (int)Math.Ceiling((double)mappedResources.Count() / ResourcesPerPage)
            };

            return filteredResources;
        }

        public async Task<DetailResources> GetResourceById(string? resourceId)
        {
            IEnumerable<DetailResources> details = await context.Resources
                .Include(r => r.User)
                .Include(r => r.Comments)
                .Include(r => r.Comments)
                .ProjectTo<DetailResources>(mapper.ConfigurationProvider)
                .Where(r => r.Id == resourceId).ToListAsync();

            var userId = currentUserService.GetUserId();

            var detailResource = details
                .FirstOrDefault(dr => (dr.Id.ToLower() == resourceId.ToLower() && dr.IsPublic) || dr.UserId == userId);

            if (detailResource == null)
            {
                return null;
            }

            if (detailResource.ResourceLikes.Any(rl => rl.UserId == userId))
            {
                detailResource.HasLiked = true;
            }

            return detailResource;
        }

        public async Task<EditResources> GetMyResourceToEdit(Guid id)
        {
            var userId = currentUserService.GetUserId();
            var foundResource = await context.Resources.FindAsync(id);

            CustomException.ThrowIfNull(foundResource, ResourceMessages.NoPermission);

            if (foundResource.UserId != userId)
            {
                CustomException.ThrowIfNull(foundResource, ResourceMessages.NoPermission);
            }

            var mappedResource = mapper.Map<EditResources>(foundResource);

            var selectedCategories = await context
                .CategoriesResources
                .Where(cr => cr.ResourceId == id)
                .ProjectTo<CategoryModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            var allCategories = await context
                .Categories
                .ProjectTo<CategoryModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            mappedResource.ChosenCategories = selectedCategories;
            mappedResource.AllAvailableCategories = allCategories;
            return mappedResource;
        }

        public int GetTotalPage()
        {
            var userId = currentUserService.GetUserId();
            var pages = (double)context
                .Resources
                .Where(r => r.IsPublic || r.UserId == userId)
                .CountAsync()
                .Result / ResourcesPerPage;

            var totalPages = (int)Math.Ceiling(pages);
            return totalPages;
        }

        public async Task<string> EditResource(string id, ResourceEditModel resourceEdit)
        {
            var resource = await context.Resources.FindAsync(Guid.Parse(id));
            if (resource == null)
            {
                throw new Exception(ResourceMessages.SuchModelDoesNotExist);
            }

            context.Entry(resource).CurrentValues.SetValues(resourceEdit);
            try
            {
                await context.SaveChangesAsync();
                return ResourceMessages.OnSuccessfulResourceEdit;
            }
            catch (DbUpdateException)
            {
                throw new Exception(ResourceMessages.OnUnsuccessfulResourceEdit);
            }
        }

        public async Task<string> RemoveResource(string id)
        {
            var userId = currentUserService.GetUserId();
            var resource = await context.Resources.FindAsync(Guid.Parse(id));


            ServiceException.ThrowIfNull(resource,ResourceMessages.SuchModelDoesNotExist);

            if (resource.UserId != userId || resource.IsDeleted)
            {
                throw new ServiceException(ResourceMessages.OnUnsuccessfulResourceRemove);
            }

            context.Remove(resource);
            await context.SaveChangesAsync();
            return ResourceMessages.OnSuccessfulResourceRemove;
        }

        public async Task<string> ChangeVisibility(string id)
        {
            var userId = currentUserService.GetUserId();
            var resource = await context.Resources.FindAsync(Guid.Parse(id));

            if (resource == null || resource.UserId != userId || resource.IsDeleted)
            {
                throw new ServiceException(ResourceMessages.NoPermission);
            }

            resource.IsPublic = !resource.IsPublic;
            await context.SaveChangesAsync();

            return ResourceMessages.SuccessfullyVisibilityChanged;
        }
    }
}