namespace _Project_CheatSheet.Features.Course.Models
{
    using Humanizer;

    public class CoursePreviewModel
    {
        public CoursePreviewModel()
        {
            this.Topics = new HashSet<TopicDetailModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int PeopleParticipating { get; set; }

        public string IntroductionVideoUrl { get; set; } = null!;

        public ICollection<TopicDetailModel> Topics { get; set; } = null!;

    }
}
