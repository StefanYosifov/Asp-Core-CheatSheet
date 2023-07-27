namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseDetailsModel
    {

        public string CourseId { get; set; }

        public string Summary{ get;set;}

        public string Description{get;set;}

        public ICollection<string> TopicCoverage{get; set;}
    }
}
