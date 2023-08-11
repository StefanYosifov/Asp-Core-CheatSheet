namespace _Project_CheatSheet.Features.Comment.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentLikeModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        public string CommentId { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
    }
}