namespace _Project_CheatSheet.Features.AWS
{
    using Common.Filters_and_Attributes.Filters;

    using Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [Route("/aws")]
    public class AwsController : ApiController
    {
        private readonly IAwsService service;

        public AwsController(IAwsService service)
        {
            this.service = service;
        }

        [HttpPost("upload/{id}")]
        [ActionHandlingFilter]
        public async Task<string> Upload(Guid id, [FromForm(Name = "Data")] IFormFile file)
            => await service.UploadFile(id, file);

        [HttpGet("{id}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> GetFile(Guid id) 
            => await service.GetFile(id);
    }
}