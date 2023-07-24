namespace _Project_CheatSheet.Features.Course.Models
{
    public class TopicDetailModel
    {
        public TopicDetailModel()
        {
            this.Resources=new List<string>();
        }

        public string Name { get; set; }

        public string Content{get;set; }

        public ICollection<string> Resources { get; set; } = null!;
    }
}
