namespace _Project_CheatSheet.Tests.Authentication
{
    using _Project_CheatSheet.Features;
    using _Project_CheatSheet.Features.Identity.Interfaces;
    using _Project_CheatSheet.Features.Identity.Models;
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;

    using Moq;

    using Xunit;

    public class AuthenticateServiceTests
    {

        private readonly Mock<IAuthenticateService> service;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<IMapper> mapper;
        private readonly Mock<SignInManager<User>> signInManager;
        private readonly Mock<UserManager<User>> userManager;

        public AuthenticateServiceTests(Mock<IAuthenticateService> service, Mock<IConfiguration> configuration, Mock<IMapper> mapper, Mock<SignInManager<User>> signInManager, Mock<UserManager<User>> userManager)
        {
            this.service = service;
            this.configuration = configuration;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [Fact]
        public void AuthenticateLogin()
        {
            var loginModel = new LoginModel()
            {
                Username = "pesho",
                Password = "pesho123",
            };

            service.Setup(s => s.AuthenticateLogin(loginModel).Result);

            var result = service.Object.AuthenticateLogin(loginModel);


            Assert.Equal(typeof(Response),result.GetType());
        }

    }
}
