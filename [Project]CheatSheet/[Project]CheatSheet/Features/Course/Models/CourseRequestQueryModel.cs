namespace _Project_CheatSheet.Features.Course.Models
{
    using Enums;

    public class CourseRequestQueryModel
    {

        public CourseRequestQueryModel()
        {
            Categories = new List<string>();
        }

        public string? Search { get; set; }

        public CourseFilters Sort { get; set; }

        public ICollection<string> Categories { get; set; }

    }
}
