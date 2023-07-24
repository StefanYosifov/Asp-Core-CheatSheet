namespace _Project_CheatSheet.Features.Course.Models
{
    using _Project_CheatSheet.Features.Course.Enums;

    public class CourseRequestQueryModel
    {

        public CourseRequestQueryModel()
        {
            this.Categories = new List<string>();
        }

        public string? Search { get; set; }

        public CourseFilters Sort { get; set; }

        public ICollection<string> Categories { get; set; }

    }
}
