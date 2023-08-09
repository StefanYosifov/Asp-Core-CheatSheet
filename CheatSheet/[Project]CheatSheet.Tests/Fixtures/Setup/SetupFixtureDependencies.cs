namespace _Project_CheatSheet.Tests.Fixtures.Setup
{
    using AutoMapper;

    using Common.Caching;
    using Common.Mapping;
    using Common.UserService.Interfaces;

    using Infrastructure.Data.SQL;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    using Moq;

    public static class SetupFixtureDependencies
    {

        internal static IMock<IHttpContextAccessor> HttpContextMock()
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
            return httpContextAccessorMock;
        }

        internal static Mock<ICurrentUser> CurrentUserServiceMock(string userIdToReturn = "pesho")
        {
            var currentUserServiceMock = new Mock<ICurrentUser>();
            currentUserServiceMock.Setup(s => s.GetUserId()).Returns(userIdToReturn);
            return currentUserServiceMock;
        }

        internal static Mock<CheatSheetDbContext> CheatSheetDbContextMock(IHttpContextAccessor httpMock)
        {
            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContextMock = new Mock<CheatSheetDbContext>(options, httpMock);

            return dbContextMock;
        }

        internal static IMapper SetupMapper(Mock<ICurrentUser> currentUserServiceMock)
        {
            var myProfile = new MapperProfile(currentUserServiceMock.Object);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            return mapper;
        }

        internal static IMemoryCache setupCache()
        {
            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var expectedMilliseconds = 100;
            var mockCache = new Mock<IMemoryCache>();
            var mockCacheEntry = new Mock<ICacheEntry>();

            string? keyPayload = null;
            mockCache
                .Setup(mc => mc.CreateEntry(It.IsAny<object>()))
                .Callback((object k) => keyPayload = (string)k)
                .Returns(mockCacheEntry.Object);

            object? valuePayload = null;
            mockCacheEntry
                .SetupSet(mce => mce.Value = It.IsAny<object>())
                .Callback<object>(v => valuePayload = v);

            TimeSpan? expirationPayload = null;
            mockCacheEntry
                .SetupSet(mce => mce.AbsoluteExpirationRelativeToNow = It.IsAny<TimeSpan?>())
                .Callback<TimeSpan?>(dto => expirationPayload = dto);
            return mockCache.Object;
        }

        internal static Mock<ICacheService> setupCacheService()
        {

            var expectedKey = "expectedKey";
            var expectedValue = "expectedValue";
            var expectedMilliseconds = 100;
            var mockCache = new Mock<IMemoryCache>();
            var mockCacheEntry = new Mock<ICacheEntry>();

            string? keyPayload = null;
            mockCache
                .Setup(mc => mc.CreateEntry(It.IsAny<object>()))
                .Callback((object k) => keyPayload = (string)k)
                .Returns(mockCacheEntry.Object);

            object? valuePayload = null;
            mockCacheEntry
                .SetupSet(mce => mce.Value = It.IsAny<object>())
                .Callback<object>(v => valuePayload = v);

            TimeSpan? expirationPayload = null;
            mockCacheEntry
                .SetupSet(mce => mce.AbsoluteExpirationRelativeToNow = It.IsAny<TimeSpan?>())
                .Callback<TimeSpan?>(dto => expirationPayload = dto);

            var cacheServiceMock = new Mock<ICacheService>();
            cacheServiceMock.Setup(service =>
                service.SetCache(expectedKey, expectedValue, expectedMilliseconds));

            return cacheServiceMock;
        }

    }
}
