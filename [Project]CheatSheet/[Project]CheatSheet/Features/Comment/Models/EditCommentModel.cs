namespace _Project_CheatSheet.Features.Comment.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Comment;
    using System.ComponentModel.DataAnnotations;

    public class EditCommentModel
    {
        [StringLength(CommentConstants.ContentMaxLength, MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}