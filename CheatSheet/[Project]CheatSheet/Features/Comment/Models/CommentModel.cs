namespace _Project_CheatSheet.Features.Comment.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Comment;
    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {
        public CommentModel()
        {
            Id = Guid.NewGuid().ToString();
            CommentLikes = new HashSet<CommentLikeModel>();
        }

        [Required] public string Id { get; set; }

        public string UserId { get; set; }
        public string? UserName { get; set; } = null!;

        [StringLength(CommentConstants.ContentMaxLength, MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public string? UserProfileImage { get; set; }
        public string? CreatedAt { get; set; } = null!;
        public string? ResourceId { get; set; }
        public bool HasLiked { get; set; }
        public int LikeCount { get; set; }
        public ICollection<CommentLikeModel> CommentLikes { get; set; }
    }
}