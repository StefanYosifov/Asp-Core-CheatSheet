namespace _Project_CheatSheet.Features.Category.Services
{
    using Infrastructure.Data.SQL;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using Resources.Enums;

    public class CategoryService : ICategoryService
    {
        private readonly CheatSheetDbContext context;

        public CategoryService(CheatSheetDbContext context)
        {
            this.context = context;
        }

        public async Task<CategorySortingModel> GetCategories()
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Select(x => new CategoryModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArrayAsync();

            var sorting = ((ResourceSorting[])Enum
                    .GetValues(typeof(ResourceSorting)))
                .Select(s => new SortingModel
                {
                    Id = (int)s,
                    Name = s.ToString()
                })
                .ToArray();

            return new CategorySortingModel
            {
                Categories = categories,
                Sorting = sorting
            };
        }
    }
}