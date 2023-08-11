namespace _Project_CheatSheet.Features.Course.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Course;

    public class CoursePaymentModel
    {
        [Required] public string CourseId { get; set; } = null!;

        [Required] public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.TitleMaxLength, MinimumLength = CourseConstants.TitleMinLength)]
        public string CourseName { get; set; } = null!;

        [StringLength(CourseConstants.DescriptionMaxLength, MinimumLength = CourseConstants.DescriptionMinLength)]
        public string CourseDescription { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }

        public string StartTime { get; set; } = null!;
    }
}