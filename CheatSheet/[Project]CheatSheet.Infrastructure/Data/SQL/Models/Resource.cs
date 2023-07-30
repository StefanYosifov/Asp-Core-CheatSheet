namespace _Project_CheatSheet.Infrastructure.Data.SQL.Models
{
    using Base;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Constants.GlobalConstants.Resource;

    public class Resource : DeletableEntity
    {
        public Resource()
        {
            CategoryResources = new HashSet<CategoryResource>();
            ResourceLikes = new HashSet<ResourceLike>();
            Comments = new HashSet<Comment>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MaxLength(ResourceConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ResourceConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [MaxLength(ResourceConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
        public bool IsPublic { get; set; }
        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}