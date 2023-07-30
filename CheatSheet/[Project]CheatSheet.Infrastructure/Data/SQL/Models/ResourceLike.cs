namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResourceLike
    {
        public ResourceLike()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Resource))] public Guid ResourceId { get; set; }

        public Resource Resource { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}