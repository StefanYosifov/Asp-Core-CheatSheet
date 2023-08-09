namespace _Project_CheatSheet.Features.Comment.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Comment;

    public class CommentInputModel
    {

        public CommentInputModel()
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
