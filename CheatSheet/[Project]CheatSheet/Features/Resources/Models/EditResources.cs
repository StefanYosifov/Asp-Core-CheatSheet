namespace _Project_CheatSheet.Features.Resources.Models
{
    using Category.Models;

    public class EditResources
    {
        public EditResources()
        {
            this.AllAvailableCategories = new HashSet<CategoryModel>();
            this.ChosenCategories = new HashSet<CategoryModel>();
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<CategoryModel> AllAvailableCategories { get; set; }

        public ICollection<CategoryModel> ChosenCategories { get; set; }
    }
}
