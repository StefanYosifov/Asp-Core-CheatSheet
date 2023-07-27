namespace _Project_CheatSheet.Features.Comment.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Comment;
    using System.ComponentModel.DataAnnotations;

    public class InputCommentModel
    {

        public InputCommentModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required] public string Id { get; set; }

        public string? UserId { get; set; }

        [StringLength(CommentConstants.ContentMaxLength, MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
        public string? ResourceId { get; set; }
    }
}
