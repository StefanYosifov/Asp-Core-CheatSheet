namespace _Project_CheatSheet.Features.Statistics.Services
{
    using _Project_CheatSheet.Common.Caching;

    using Constants.CachingConstants;

    using Infrastructure.Data;
    using Interfaces;
    using Microsoft.Extensions.Caching.Memory;
    using Models;

    public class StatisticsService : IStatisticsService
    {
        private readonly IMemoryCache cache;
        private readonly ICacheService cacheService;
        private readonly CheatSheetDbContext context;
        public StatisticsService(
            CheatSheetDbContext context,
            ICacheService cacheService,
            IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
            this.cacheService = cacheService;
        }

        public StatisticsModel GetAllStatistics()
        {
            const string cacheKey = "home";
            if (cache.TryGetValue(cacheKey, out StatisticsModel statisticModel))
            {
                return statisticModel;
            }

            var newStatisticsModel = new StatisticsModel
            {
                ResourcesCount = context.Resources.Count(),
                UsersCount = context.Users.Count()
            };

            cacheService.SetCache(cacheKey, newStatisticsModel, CachingConstants.Course.HomeStatistics);
            return newStatisticsModel;
        }

        public StatisticsCourseModel GetStatisticsCourse()
        {
            const string cacheKey="Course_Statistics";
            if(cache.TryGetValue(cache,out StatisticsCourseModel statisticModel))
            {
                return statisticModel;
            }

            var newStatisticsModel=new StatisticsCourseModel
            {
                CoursesCount = context.Courses.Count(),
                UserCoursesCount=context.UserCourses.Count()
            };
            cacheService.SetCache(cacheKey,newStatisticsModel,CachingConstants.Course.CourseStatistics);
            return newStatisticsModel;
        }
    }
}