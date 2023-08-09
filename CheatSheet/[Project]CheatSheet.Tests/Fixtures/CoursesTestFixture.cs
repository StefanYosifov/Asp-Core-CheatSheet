namespace _Project_CheatSheet.Tests.Fixtures
{
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
    using _Project_CheatSheet.Tests.Fixtures.Setup;
    using Features.Course.Interfaces;
    using Features.Course.Services;
    using Features.Topics.Interfaces;
    using Features.Videos.Interfaces;

    using Infrastructure.Data.SQL;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    public class CoursesTestFixture : IDisposable
    {
        public ICourseService CourseService { get; private set; }
        public ITopicService TopicService { get; private set; }
        public IVideoService VideoService { get; private set; }

        public CheatSheetDbContext DbContext { get; private set; }

        public CoursesTestFixture()
        {
            const string userId = "pesho";

            var httpContextAccessorMock = SetupFixtureDependencies.HttpContextMock();
            var currentUserServiceMock = SetupFixtureDependencies.CurrentUserServiceMock(userId);
            var mapper = SetupFixtureDependencies.SetupMapper(currentUserServiceMock);
            var memoryCache = SetupFixtureDependencies.setupCache();
            var cacheService = SetupFixtureDependencies.setupCacheService().Object;

            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase("RandomName")
                .Options;
            this.DbContext = new CheatSheetDbContext(options, httpContextAccessorMock.Object);

            SetupInitializeData.IntializeDataForCourses(DbContext);

            var courseServiceMock = new Mock<CourseService>(DbContext,mapper,currentUserServiceMock.Object,memoryCache,cacheService);


            CourseService=courseServiceMock.Object;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
