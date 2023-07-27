namespace _Project_CheatSheet.Features.Course.Services
{
    using Common.CachingConstants;
    using Enums;
    using _Project_CheatSheet.Infrastructure.MongoDb.Services;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Caching;
    using Common.Pagination;
    using Common.UserService.Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Models;

    using static Common.CachingConstants.CachingConstants.Course;
    using Course = Infrastructure.Data.Models.Course;

    public class CourseService : ICourseService
    {
        private readonly string[] featuredCategories = new string[] { "C#", "JavaScript", "Python", "Java", "Web" };
        private const int FeaturedCategoriesCount = 6;
        private const byte CoursesPerPage = 6;


        private readonly IMemoryCache cache;
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;
        private readonly ICacheService setCache;

        public CourseService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService,
            IMemoryCache cache,
            ICacheService setCache
            )
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
            this.cache = cache;
            this.setCache = setCache;
        }

        public async Task<bool> JoinCourse(string id)
        {
            var getCourse = await context.Courses.FindAsync(id);

            if (getCourse == null)
            {
                return false;
            }

            var userId = currentUserService.GetUserId();

            if (getCourse.UsersCourses.Any(uc => uc.UserId == userId))
            {
                return false;
            }

            var userCourse = new UserCourses
            {
                Course = getCourse,
                CourseId = getCourse.Id,
                UserId = userId
            };

            context.UserCourses.Add(userCourse);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CourseRespondAllPaginated> GetAllCourses(int page, CourseRequestQueryModel query)
        {
            var userId = currentUserService.GetUserId();
            string splitQueryCategoriesText = string.Join(',', query.Categories);
            string[] splitQueryCategoriesArr = splitQueryCategoriesText.Split(',');
            var cacheKey = $"Courses_{page}_{query.Search}_{query.Sort}_{splitQueryCategoriesText}";


            if (cache.TryGetValue(cacheKey, out CourseRespondAllPaginated cachedResult))
            {
                return cachedResult;
            }

            var courses = context.Courses.AsNoTracking();

            if (!string.IsNullOrEmpty(query.Search))
            {
                var wildcard = $"%{query.Search.ToLower()}%";

                courses = courses.Where(c => EF.Functions.Like(c.Title.ToLower(), wildcard));
            }

            if (query.Categories.Count > 0)
            {
                courses = courses.Where(c => c.CategoryCourseCourses.Any(cc => splitQueryCategoriesArr.Contains(cc.CategoryCourse.Name)));
            }

            if (query.Sort != null && query.Sort.ToString() != "All")
            {
                courses = query.Sort switch
                {
                    CourseFilters.Active => courses.Where(c => c.StartDate > DateTime.UtcNow),
                    CourseFilters.Passed => courses.Where(c => c.StartDate < DateTime.UtcNow),
                    CourseFilters.OnGoing => courses.Where(c => c.StartDate < DateTime.UtcNow && c.EndDate > DateTime.UtcNow),
                };
            }

            var mappedCourses = courses.ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);

            var paginationResult =
                await Pagination<CourseRespondAllModel>.CreateAsync(mappedCourses, page, CoursesPerPage);

            var allCoursesResult = new CourseRespondAllPaginated
            {
                Courses = paginationResult,
                TotalPages = (int)Math.Ceiling((decimal)mappedCourses.Count() / CoursesPerPage)
            };

            setCache.SetCache(cacheKey, allCoursesResult, PublicCoursesCache);

            return allCoursesResult;
        }

        public async Task<IEnumerable<CourseRespondAllModel>> GetMyCourses(int page, string? toggle)
        {
            var userId = currentUserService.GetUserId();
            var isArchived = string.IsNullOrWhiteSpace(toggle) || toggle == "true";

            var cacheKey = $"My_Courses_{userId}_{page}_{isArchived}";
            if (cache.TryGetValue(cacheKey, out IEnumerable<CourseRespondAllModel> cachedResult))
            {
                return cachedResult;
            }

            var courseResult = context.Courses
                .AsNoTracking()
                .Where(uc => uc.UsersCourses.Any(c => c.UserId == userId));

            var filteredResults = FilterWhetherArchiveOrNotQuery(isArchived, courseResult);

            var paginationResult = await Pagination<CourseRespondAllModel>.CreateAsync(filteredResults, page);

            foreach (var course in
                     paginationResult) //Todo think of better way to implement, without the need of yet another class
            {
                course.HasPaid = true;
            }

            setCache.SetCache(cacheKey, paginationResult, MyCoursesCache);

            return paginationResult;
        }

        public async Task<CourseRespondModel> GetCourseDetails(string id)
        {
            var userId = currentUserService.GetUserId();
            var course = await context.Courses
                .Include(u => u.UsersCourses)
                .FirstOrDefaultAsync(c => c.Id.ToString() == id && c.UsersCourses.Any(uc => uc.UserId == userId));

            if (course == null)
            {
                return null;
            }

            return mapper.Map<CourseRespondModel>(course);
        }

        public async Task<CourseRespondPaymentModel> GetPaymentDetails(string id)
        {
            var getCourse = await context.Courses.FindAsync(Guid.Parse(id));
            return mapper.Map<CourseRespondPaymentModel>(getCourse);
        }

        public async Task<CourseFilterModel> GetCoursesFilteringData()
        {
            const string cacheKey = "Course_Languages";
            if (cache.TryGetValue(cacheKey, out CourseFilterModel filters))
            {
                return filters;
            }

            var languages = await context.CategoryCourses
                .AsNoTracking()
                .Select(cc => cc.Name)
                .ToArrayAsync();

            string[] filterEnum = Enum.GetValues(typeof(CourseFilters))
                            .Cast<CourseFilters>()
                            .Select(x => x.ToString())
                            .ToArray();

            var sortingModel = new CourseFilterModel
            {
                Categories = languages,
                Sortings = filterEnum,
            };

            setCache.SetCache(cacheKey, sortingModel, CategoriesCoursesCache);

            return sortingModel;
        }

        private IQueryable<CourseRespondAllModel> FilterWhetherArchiveOrNotQuery(bool isArchived,
            IQueryable<Course> courseResult)
        {
            IQueryable<CourseRespondAllModel> filteredResults;
            var currentDate = DateTime.Now;
            if (isArchived)
            {
                filteredResults = courseResult
                    .Where(c => c.EndDate <= currentDate)
                    .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);
            }
            else
            {
                filteredResults = courseResult
                    .Where(c => c.EndDate > currentDate)
                    .ProjectTo<CourseRespondAllModel>(mapper.ConfigurationProvider);
            }

            return filteredResults;
        }

        public async Task<ICollection<CourseRespondUpcomingModel>> GetUpcomingCourses()
        {


            var userId = currentUserService.GetUserId();
            var cacheKey = $"upcomingCourses_{userId}";

            if (cache.TryGetValue(cacheKey, out ICollection<CourseRespondUpcomingModel> upcomingCourses))
            {
                return upcomingCourses;
            }

            var getUpComingCourses = await context.Courses
                .AsNoTracking()
                .Include(c => c.CategoryCourseCourses)
                .ThenInclude(cc => cc.Course)
                .Where(c => c.StartDate > DateTime.UtcNow && c.CategoryCourseCourses.Any(ccc => featuredCategories.Contains(ccc.CategoryCourse.Name)))
                .Take(FeaturedCategoriesCount)
                .OrderBy(x => x.StartDate)
                .ProjectTo<CourseRespondUpcomingModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            setCache.SetCache(cacheKey, getUpComingCourses, CachingConstants.Course.UpComingCourses);
            return getUpComingCourses;
        }


    public async Task<CoursePreviewModel> GetPreviewCourseData(string id)
    {
        var courseDetailsData = await context.Courses
            .Include(c => c.Topics)
            .ThenInclude(t => t.Video)
            .Include(c => c.UsersCourses)
            .FirstOrDefaultAsync(c => c.Id.ToString() == id);

        return new CoursePreviewModel()
        {
            Id = courseDetailsData.Id.ToString(),
            Name = courseDetailsData.Title,
            Price = courseDetailsData.Price,
            IntroductionVideoUrl = courseDetailsData.Topics.Where(t => t.CourseId.ToString() == id).Select(v => v.Video.VideoUrl).FirstOrDefault(),
            PeopleParticipating = courseDetailsData.UsersCourses.Count(uc => uc.CourseId.ToString() == id),
            Topics = courseDetailsData.Topics.Select(topic => new TopicDetailModel
            {
                Name = topic.Name,
                Content = topic.Content,
                Resources = new List<string> { topic.Video.Name }
            }).ToList()
        };

    }
}
}