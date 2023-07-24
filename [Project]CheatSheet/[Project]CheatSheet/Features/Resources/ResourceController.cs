namespace _Project_CheatSheet.Features.Resources
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Resource;
    using Common.Filters;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Models;

    [Route("/resource")]
    [Authorize]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet("pages")]
        public IActionResult GetPageCount()
            => Ok(resourceService.GetTotalPage());

        [HttpGet("{id}")]
        [ActionFilter]
        public async Task<ResourceCollectionModel> GetAllResources(int id, [FromQuery] ResourceQueryModel query)
            => await resourceService.GetPublicResources(id, query);

        [HttpGet("my")]
        public async Task<IEnumerable<ResourceModel>> GetMyResources()
            => await resourceService.GetMyResources();

        [HttpGet("details/{id}")]
        [ActionFilter("", ResourceMessages.SuchModelDoesNotExist, StatusCodes.Status404NotFound)]
        [ExceptionHandlingActionFilter]
        public async Task<DetailResources> GetResourceDetails(string id)
            => await resourceService.GetResourceById(id);

        [HttpPost("add")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> AddResource([FromBody] ResourceAddModel resourceAdd)
            => await resourceService.AddResources(resourceAdd);

        [HttpPatch("edit/{id}")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<IActionResult> EditResource(string id, [FromBody] ResourceEditModel resourceEdit)
        {
            if (!await TryUpdateModelAsync(resourceEdit))
            {
                return NotFound(ResourceMessages.OnInvalidRequestsResourceEdit);
            }
            var resourceResult = await resourceService.EditResource(id, resourceEdit);
            return Ok(resourceResult);
        }

        [HttpDelete("delete/{id}")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> RemoveResource(string id)
            => await resourceService.RemoveResource(id);

        [HttpPatch("visibility/{id}")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> ChangeVisibility(string id)
            => await resourceService.ChangeVisibility(id);
    }
}