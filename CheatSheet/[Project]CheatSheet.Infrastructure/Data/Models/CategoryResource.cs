namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoryResource
    {
        [ForeignKey(nameof(Category))] public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [ForeignKey(nameof(Resource))] public Guid ResourceId { get; set; }

        public virtual Resource Resource { get; set; } = null!;
    }
}