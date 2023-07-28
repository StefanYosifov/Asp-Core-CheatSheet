namespace _Project_CheatSheet.Features.Comment.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Comment;

    public class EditCommentModel
    {
        [StringLength(CommentConstants.ContentMaxLength, MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}