namespace _Project_CheatSheet.Tests.Authentication
{
    using Infrastructure.Data.SQL.Models;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Moq;

    public class FakeSignInManager : SignInManager<User>
    {
        public FakeSignInManager()
            : base(new FakeUserManager(),
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<User>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<DefaultUserConfirmation<User>>().Object)
        { }        
    }
}
