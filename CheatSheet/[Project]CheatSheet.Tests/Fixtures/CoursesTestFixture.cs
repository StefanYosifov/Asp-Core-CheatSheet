namespace _Project_CheatSheet.Tests.Fixtures
{
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
    using _Project_CheatSheet.Tests.Fixtures.Setup;

    using Amazon.S3;

    using Features.Course.Interfaces;
    using Features.Course.Services;
    using Features.Issue.Interfaces;
    using Features.Issue.Services;
    using Features.Topics.Interfaces;
    using Features.Topics.Services;
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

        public IIssueService IssueService { get; private set; }

        public CheatSheetDbContext DbContext { get; private set; }

        public CoursesTestFixture()
        {
            const string userId = "pesho";

            //Todo Figure out a way to improve this, maybe with out?
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

            var s3ClientMock = new Mock<IAmazonS3>();
            var courseServiceMock = new Mock<CourseService>(DbContext, mapper, currentUserServiceMock.Object, memoryCache, cacheService);
            var topicServiceMock = new Mock<TopicService>(DbContext, mapper, s3ClientMock.Object);
            var issueServiceMock = new Mock<IssueService>(DbContext, mapper, currentUserServiceMock.Object);

            CourseService = courseServiceMock.Object;
            TopicService = topicServiceMock.Object;
            IssueService = issueServiceMock.Object;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
