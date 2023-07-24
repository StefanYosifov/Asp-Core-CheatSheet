namespace _Project_CheatSheet.Features.Comment.Models
{
    public class CommentLikeModel
    {
        public string Id { get; set; } = null!;

        public string CommentId { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}