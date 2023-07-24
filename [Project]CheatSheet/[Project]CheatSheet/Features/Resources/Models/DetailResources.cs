namespace _Project_CheatSheet.Features.Resources.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Resource;
    using Infrastructure.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class DetailResources
    {
        public DetailResources()
        {
            ResourceLikes = new HashSet<ResourceLike>();
            CategoryNames = new List<string>();
            ResourceComments = new HashSet<ResourceCommentModel>();
        }

        [Required] public string Id { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.TitleMaxLength, MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ImageUrlMinLength, MinimumLength = ResourceConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public bool IsPublic { get; set; }
        public string DateTime { get; set; } = null!;
        public int Likes { get; set; }
        public bool HasLiked { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
        public IEnumerable<ResourceLike> ResourceLikes { get; set; }
        public IEnumerable<ResourceCommentModel> ResourceComments { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
    }
}