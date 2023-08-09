namespace _Project_CheatSheet.Features.Identity.Interfaces
{
    using Models;

    public interface IAuthenticateService
    {
        Task<Response> AuthenticateLogin(IdentityLoginModel identityLoginModel);

        Task<Response> AuthenticateRegister(IdentityRegisterModel identityRegisterModel);
    }
}