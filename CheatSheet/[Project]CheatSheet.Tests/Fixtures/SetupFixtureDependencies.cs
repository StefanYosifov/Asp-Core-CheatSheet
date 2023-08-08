namespace _Project_CheatSheet.Tests.Fixtures
{
    using AutoMapper;

    using Common.Mapping;
    using Common.UserService.Interfaces;

    using Infrastructure.Data.SQL;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    public static class SetupFixtureDependencies
    {

        internal static IMock<IHttpContextAccessor> HttpContextMock()
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
            return httpContextAccessorMock;
        }

        internal static Mock<ICurrentUser> CurrentUserServiceMock(string userIdToReturn="pesho")
        {
            var currentUserServiceMock = new Mock<ICurrentUser>();
            currentUserServiceMock.Setup(s => s.GetUserId()).Returns(userIdToReturn);
            return currentUserServiceMock;
        }

        internal static Mock<CheatSheetDbContext> CheatSheetDbContextMock(IMock<IHttpContextAccessor> httpMock)
        {
            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new Mock<CheatSheetDbContext>(options, httpMock.Object);
        }

        internal static IMapper SetupMapper(Mock<ICurrentUser> currentUserServiceMock)
        {
            var myProfile = new MapperProfile(currentUserServiceMock.Object);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            return mapper;
        }

    }
}
