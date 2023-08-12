namespace _Project_CheatSheet.Tests.Videos
{
    using Common.Exceptions;

    using Features.Resources.Services;
    using Features.Videos.Interfaces;
    using Features.Videos.Services;

    using Fixtures.Setup;

    using Infrastructure.Data.SQL;

    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class VideoTests : IDisposable
    {

        private readonly IVideoService videoService;
        private readonly CheatSheetDbContext DbContext;
        private const string userId = "pesho";

        public VideoTests()
        {
            var httpContextAccessorMock = SetupFixtureDependencies.HttpContextMock();
            var currentUserServiceMock = SetupFixtureDependencies.CurrentUserServiceMock(userId);
            var memoryCache = SetupFixtureDependencies.setupCache();
            var cacheService = SetupFixtureDependencies.setupCacheService();


            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase("RandomName")
                .Options;
            this.DbContext = new CheatSheetDbContext(options, httpContextAccessorMock.Object);

            SetupInitializeData.IntializeDataForCourses(DbContext);

            var videoServiceMock = new Mock<VideoService>(DbContext, currentUserServiceMock.Object, memoryCache, cacheService.Object);

            this.videoService = videoServiceMock.Object;
        }

        [Fact]
        public async Task GetVideoIdShouldReturnJustTheIdOfTheYoutubeVideo()
        {
            var getTopic = await DbContext.Topics.Include(t=>t.Video).FirstOrDefaultAsync(t => t.VideoId != null);
            var expectedString=getTopic.Video.VideoUrl.Split("=")[1];

            var result = await videoService.GetVideoId(getTopic.Id);

            Assert.NotNull(result);
            Assert.Equal(expectedString, result);
        }

        [Fact]
        public async Task GetVideoIdShouldThrowExceptionIfTheTopicDoesNotExist()
        {
            var randomId = Guid.NewGuid();

            await Assert.ThrowsAsync<CustomException>(()=>videoService.GetVideoId(randomId));

        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
