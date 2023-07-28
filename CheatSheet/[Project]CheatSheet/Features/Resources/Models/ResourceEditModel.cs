namespace _Project_CheatSheet.Features.Resources.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Resource;

    public class ResourceEditModel
    {
        public ResourceEditModel()
        {
            CategoryIds = new HashSet<int>();
        }

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