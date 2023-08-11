namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseAllPaginatedModel
    {

        public CourseAllPaginatedModel()
        {
            this.Courses=new HashSet<CourseAllModel>();
        }
        public int TotalPages{get;set; }

        public ICollection<CourseAllModel> Courses { get; set; }

    }
}
