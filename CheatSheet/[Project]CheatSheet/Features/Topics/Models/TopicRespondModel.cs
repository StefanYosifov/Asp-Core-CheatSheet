namespace _Project_CheatSheet.Features.Topics.Models
{
    public class TopicRespondModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IFormFile File{get;set; }

        public string VideoId { get; set; }
        public string VideoName { get; set; }
    }
}