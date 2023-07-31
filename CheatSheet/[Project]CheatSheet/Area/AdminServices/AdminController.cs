namespace _Project_CheatSheet.Area.AdminServices
{
    using Common.Filters;

    using Features;

    using Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    [Authorize(Policy = "ElevatedRights")]
    [Route("/admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet("resources")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter()]
        public async Task<ICollection<ResourceAdminModel>> GetResources([FromQuery]ResourceAdminQueryModel query)
            => await service.GetListOfCourses(query);


    }
}
