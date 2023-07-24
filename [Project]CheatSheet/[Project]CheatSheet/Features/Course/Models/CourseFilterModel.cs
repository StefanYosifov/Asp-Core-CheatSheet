namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseFilterModel
    {

        public CourseFilterModel()
        {
            this.Sortings = new HashSet<string>();
            this.Categories = new HashSet<string>();
        }
        public ICollection<string> Sortings { get; set; }
        public ICollection<string> Categories { get; set; }
    }
}
