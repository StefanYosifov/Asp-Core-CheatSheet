namespace _Project_CheatSheet.Features.Course.Models
{
    public class CourseRespondPaymentModel
    {

        public string CourseId { get; set; }

        public string ImageUrl { get; set; }
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public decimal Price { get; set; }

        public string StartTime { get; set; }
    }
}
