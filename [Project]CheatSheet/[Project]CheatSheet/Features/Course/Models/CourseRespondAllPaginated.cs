namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseRespondAllPaginated
    {

        public CourseRespondAllPaginated()
        {
            this.Courses=new HashSet<CourseRespondAllModel>();
        }
        public int TotalPages{get;set; }

        public ICollection<CourseRespondAllModel> Courses { get; set; }

    }
}
