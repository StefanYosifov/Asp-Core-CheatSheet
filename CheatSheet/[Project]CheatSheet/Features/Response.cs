namespace _Project_CheatSheet.Features
{
    public class Response
    {
        public ICollection<string> Roles { get; set; }

        public string AccessToken { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}