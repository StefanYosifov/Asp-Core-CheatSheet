namespace _Project_CheatSheet.Area.AdminServices.Models.Courses
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Topic;
    using Constants.GlobalConstants.Videos;

    public class TopicCreateDetailsAdminModel
    {

        [Required]
        [StringLength(VideoConstants.VideoNameMaxLength, MinimumLength = VideoConstants.VideoNameMinLength)]
        public string VideoName { get; set; } = null!;

        [Required]
        [Url]
        public string VideoUrl { get; set; } = null!;

        [Required]
        [StringLength(TopicConstants.NameMaxLength)]
        public string TopicName { get; set; } = null!;

        [Required]
        [StringLength(TopicConstants.ContentMaxLength, MinimumLength = TopicConstants.ContentMinLength)]
        public string TopicContent { get; set; } = null!;

        [Required]
        public string TopicStartDate { get; set; } = null!;

        [Required]
        public string TopicEndDate { get; set; } = null!;

    }
}
