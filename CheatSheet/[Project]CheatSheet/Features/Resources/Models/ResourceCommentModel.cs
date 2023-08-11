namespace _Project_CheatSheet.Features.Resources.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Comment;

    public class ResourceCommentModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(CommentConstants.ContentMaxLength,MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

    }
}
