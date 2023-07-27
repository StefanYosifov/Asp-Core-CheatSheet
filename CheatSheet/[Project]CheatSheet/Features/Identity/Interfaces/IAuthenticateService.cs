namespace _Project_CheatSheet.Features.Identity.Interfaces
{
    using Models;

    public interface IAuthenticateService
    {
        Task<Response> AuthenticateLogin(LoginModel loginModel);

        Task<Response> AuthenticateRegister(RegisterModel registerModel);
    }
}