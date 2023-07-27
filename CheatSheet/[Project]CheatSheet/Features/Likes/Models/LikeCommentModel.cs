namespace _Project_CheatSheet.Features.Likes.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LikeCommentModel
    {
        [Required] public string CommentId { get; set; } = null!;
    }
}