namespace _Project_CheatSheet.Area.AdminServices.Models.Courses
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Topic;
    using Constants.GlobalConstants.Videos;

    public class CoursePrimaryDetailsAdminModel
    {

        [Required] public string TopicId { get; set; } = null!;

        [Required]
        [StringLength(TopicConstants.NameMaxLength)]
        public string TopicName { get; set; } = null!;

        [Required]
        [Url]
        public string VideoUrl { get; set; }

        [Required]
        [StringLength(VideoConstants.VideoNameMaxLength, MinimumLength = VideoConstants.VideoNameMinLength)]
        public string VideoName { get; set; }

    }
}
