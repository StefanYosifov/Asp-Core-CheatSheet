namespace _Project_CheatSheet.Features.Category.Interfaces
{
    using Models;

    public interface ICategoryService
    {
        public Task<CategorySortingModel> GetCategories();
    }
}