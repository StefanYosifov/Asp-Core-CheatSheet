namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using Base;
    using Enums;
    using GlobalConstants.Course;
    using System.ComponentModel.DataAnnotations;

    public class Course : Entity
    {
        public Course()
        {
            this.Topics = new HashSet<Topic>();
            this.UsersCourses = new HashSet<UserCourses>();
            this.CategoryCourseCourses=new HashSet<CategoryCourseCourses>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(CourseConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(CourseConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }

        [Required] public string ImageUrl { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<UserCourses> UsersCourses { get; set; }

        public ICollection<CategoryCourseCourses> CategoryCourseCourses{get;set; }

    }
}