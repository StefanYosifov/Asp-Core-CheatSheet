namespace _Project_CheatSheet.Features.Course.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Course;

    public class CourseAllModel
    {
        public CourseAllModel()
        {
            this.Categories = new HashSet<string>();
        }

        public string Id { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.TitleMaxLength, MinimumLength = CourseConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.DescriptionMaxLength, MinimumLength = CourseConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(CourseConstants.PriceMinRange, CourseConstants.PriceMaxRange)]
        public decimal Price { get; set; }

        [Required][Url] public string ImageUrl { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool HasPaid { get; set; }

        public int TopicsCount { get; set; }

        [Required]
        public ICollection<string> Categories { get; set; }
    }
}