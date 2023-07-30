namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommentLike : BaseEntity
    {
        public CommentLike()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Comment))] public Guid CommentId { get; set; }

        public Comment Comment { get; set; } = null!;
    }
}