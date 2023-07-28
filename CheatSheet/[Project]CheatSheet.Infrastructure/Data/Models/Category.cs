namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Category;

    public class Category
    {
        public Category()
        {
            CategoryResources = new HashSet<CategoryResource>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CategoryConstants.NameMaxCategory)]
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}