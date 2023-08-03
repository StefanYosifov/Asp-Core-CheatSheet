namespace _Project_CheatSheet.Area.AdminServices.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Course;

    public class CreateCourseAdminModel
    {
        [Required]
        [StringLength(CourseConstants.TitleMaxLength,MinimumLength = CourseConstants.TitleMinLength)]
        public string CourseName { get; set; }= null!;

        [Required]
        [StringLength(CourseConstants.DescriptionMaxLength,MinimumLength = CourseConstants.DescriptionMinLength)]
        public string CourseDescription { get; set; }= null!;

        [Required]
        [Range(CourseConstants.PriceMinRange,CourseConstants.PriceMaxRange)]
        public decimal CoursePrice { get; set; }

        [Required]
        [Url]
        public string CourseImageUrl { get; set; }= null!;

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        [StringLength(CourseConstants.SummaryMaxLength,MinimumLength = CourseConstants.SummaryMinLength)]
        public string Summary { get; set; }= null!;

        [Required]
        [StringLength(CourseConstants.CoverageMaxLength, MinimumLength = CourseConstants.CoverageMinLength)]
        public string CourseCoverage { get; set; } = null!;

    }
}
