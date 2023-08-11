namespace _Project_CheatSheet.Features.Course.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CourseDetailsModel
    {
        public CourseDetailsModel()
        {
            TopicCoverage = new List<string>();
        }

        [Required]
         public string CourseId { get; set; } = null!;

        public string Summary{ get;set;}

        public string Description { get; set; } = null!;

        public ICollection<string> TopicCoverage{get; set;}
    }
}
