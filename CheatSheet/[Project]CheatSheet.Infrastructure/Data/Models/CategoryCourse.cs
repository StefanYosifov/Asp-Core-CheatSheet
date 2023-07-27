namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class CategoryCourse
    {

        public CategoryCourse()
        {
            this.CategoryCourseCourses=new HashSet<CategoryCourseCourses>();
        }

        public int Id { get; set; }

        public string Name{get;set; }

        public ICollection<CategoryCourseCourses> CategoryCourseCourses { get; set; }

    }
}
