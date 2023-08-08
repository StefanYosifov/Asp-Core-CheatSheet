namespace _Project_CheatSheet.Common.Extensions
{
    using System.Security.Claims;

    public static class UserExtensions
    {

        public static string? GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
