namespace _Project_CheatSheet.Features.Resources.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Resource;
    using System.ComponentModel.DataAnnotations;

    public class ResourceEditModel
    {
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

        public ICollection<int> CategoryIds { get; set; }
    }
}