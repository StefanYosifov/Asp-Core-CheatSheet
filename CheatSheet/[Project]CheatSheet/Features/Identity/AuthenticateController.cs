namespace _Project_CheatSheet.Features.Identity
{
    using Common.Filters_and_Attributes.Filters;

    using Constants.GlobalConstants.User;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [AllowAnonymous]
    [Route("/authenticate")]
    public class AuthenticateController : ApiController
    {
        private readonly IAuthenticateService service;

        public AuthenticateController(IAuthenticateService service)
        {
            this.service = service;
        }

        [HttpPost("login")]
        [ActionHandlingFilter("", UserIdentityMessages.FailedLogin)]
        [ExceptionHandlingActionFilter()]
        public async Task<Response> Login(IdentityLoginModel identityLoginModel)
            => await service.AuthenticateLogin(identityLoginModel);

        [HttpPost("register")]
        [ExceptionHandlingActionFilter()]
        public async Task<Response> Register(IdentityRegisterModel identityRegisterModel)
            => await service.AuthenticateRegister(identityRegisterModel);
    }
}