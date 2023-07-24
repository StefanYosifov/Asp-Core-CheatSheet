namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryCourseCourses
    {
        [ForeignKey(nameof(CategoryCourse))]
        public int CategoryCourseId{get;set;}

        public CategoryCourse CategoryCourse {get;set;}=null!;

        [ForeignKey(nameof(Course))]
        public Guid CourseId{get;set;}

        public Course Course{get;set; } =null!;
    }
}
