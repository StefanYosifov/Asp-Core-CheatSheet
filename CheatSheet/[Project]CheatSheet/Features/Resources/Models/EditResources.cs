namespace _Project_CheatSheet.Features.Resources.Models
{
    using System.ComponentModel.DataAnnotations;

    using Category.Models;

    using Constants.GlobalConstants.Resource;

    public class EditResources
    {
        public EditResources()
        {
            this.AllAvailableCategories = new HashSet<CategoryModel>();
            this.ChosenCategories = new HashSet<CategoryModel>();
        }

        [StringLength(ResourceConstants.TitleMaxLength,MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; }

        [StringLength(ResourceConstants.ContentMaxLength,MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public ICollection<CategoryModel> AllAvailableCategories { get; set; }

        public ICollection<CategoryModel> ChosenCategories { get; set; }
    }
}
