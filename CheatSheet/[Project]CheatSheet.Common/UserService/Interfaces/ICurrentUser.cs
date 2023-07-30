namespace _Project_CheatSheet.Common.UserService.Interfaces
{
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

    public interface ICurrentUser
    {
        public Task<User> GetUser();

        public string GetUserId();

        public string GetUserName();
    }
}