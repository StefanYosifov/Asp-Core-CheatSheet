namespace _Project_CheatSheet.Features.Category.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Category;

    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.NameMaxCategory, MinimumLength = CategoryConstants.NameMinCategory)]
        public string Name { get; set; } = null!;

    }
}