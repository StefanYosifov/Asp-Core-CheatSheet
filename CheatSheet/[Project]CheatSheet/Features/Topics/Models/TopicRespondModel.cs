namespace _Project_CheatSheet.Features.Topics.Models
{
    public class TopicRespondModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;            

        public IFormFile File { get; set; } = null!;

        public string VideoId { get; set; } = null!;
        public string VideoName { get; set; } = null!;
    }
}