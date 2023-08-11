namespace _Project_CheatSheet.Features.Course.Models
{
    public class TopicsModel
    {
        public string TopicId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}