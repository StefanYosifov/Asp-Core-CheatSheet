namespace _Project_CheatSheet.Area.AdminServices.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Topic;
    using Constants.GlobalConstants.Videos;

    public class CourseSecondaryDetailsEditAdminModel
    {
        [Required]
        [StringLength(TopicConstants.NameMaxLength)]
        public string TopicName { get; set; } = null!;

        [Required]
        [StringLength(TopicConstants.ContentMaxLength, MinimumLength = TopicConstants.ContentMinLength)]
        public string TopicContent { get; set; } = null!;

        [Required]
        [StringLength(VideoConstants.VideoNameMaxLength, MinimumLength = VideoConstants.VideoNameMinLength)]
        public string VideoName { get; set; } = null!;

        [Required] [Url] public string VideoUrl { get; set; } = null!;

        [Required] public string StartTime { get; set; } = null!;

        [Required] public string EndTime { get; set; } = null!;
    }
}
