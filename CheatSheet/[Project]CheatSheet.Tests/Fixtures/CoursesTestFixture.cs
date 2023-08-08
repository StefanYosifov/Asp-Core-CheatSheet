namespace _Project_CheatSheet.Tests.Fixtures
{
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

    using Features.Course.Interfaces;
    using Features.Course.Services;
    using Features.Topics.Interfaces;
    using Features.Videos.Interfaces;

    using Infrastructure.Data.SQL;

    using Microsoft.AspNetCore.Identity;

    using Moq;

    internal class CoursesTestFixture : IDisposable
    {
        public ICourseService CourseService { get; private set; }
        public ITopicService TopicService {get; private set; }
        public IVideoService VideoService { get; private set; }

        public CheatSheetDbContext DbContext { get; private set; }

        public CoursesTestFixture()
        {
            const string userId = "pesho";

            var httpContextAccessorMock = SetupFixtureDependencies.HttpContextMock();
            var currentUserServiceMock = SetupFixtureDependencies.CurrentUserServiceMock(userId);
            var mapper = SetupFixtureDependencies.SetupMapper(currentUserServiceMock);
            this.DbContext = SetupFixtureDependencies.CheatSheetDbContextMock(httpContextAccessorMock).Object;

            //var courseServiceMock = Mock<CourseService>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
