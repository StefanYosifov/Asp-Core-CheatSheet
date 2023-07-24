namespace _Project_CheatSheet.Features.Category.Models
{
    public class CategorySortingModel
    {
        public CategorySortingModel()
        {
            this.Categories=new HashSet<CategoryModel>();
            this.Sorting=new HashSet<SortingModel>();
        }

        public ICollection<CategoryModel> Categories { get; set; }

        public ICollection<SortingModel> Sorting{get;set; }

    }
}
