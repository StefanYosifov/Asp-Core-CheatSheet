namespace _Project_CheatSheet.Features.Resources.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Resource;

    public class ResourceModel
    {
        public ResourceModel()
        {
            CategoryNames = new List<string>();
        }

        [Required] public string Id { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.TitleMaxLength, MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ImageUrlMinLength)]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public int TotalLikes { get; set; }
        public string DateTime { get; set; } = null!;
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserProfileImageUrl { get; set; }
        public IEnumerable<string>? CategoryNames { get; set; }
    }
}