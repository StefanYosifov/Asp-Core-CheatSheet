namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using Base;
    using Enums;

    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Course;

    public class Course : Entity
    {
        public Course()
        {
            Topics = new HashSet<Topic>();
            UsersCourses = new HashSet<UserCourses>();
            CategoryCourseCourses = new HashSet<CategoryCourseCourses>();
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

        public ICollection<CategoryCourseCourses> CategoryCourseCourses { get; set; }

    }
}