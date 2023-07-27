namespace _Project_CheatSheet.Features.Category
{
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<CategorySortingModel> GetCategory()
            => await service.GetCategories();
    }
}