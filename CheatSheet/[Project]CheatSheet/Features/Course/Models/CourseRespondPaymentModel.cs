namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseRespondPaymentModel
    {

        public string CourseId { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public string CourseName { get; set; } = null!;

        public string CourseDescription { get; set; } = null!;

        public decimal Price { get; set; }

        public string StartTime { get; set; } = null!;
    }
}
