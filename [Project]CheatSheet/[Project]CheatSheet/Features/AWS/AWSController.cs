namespace _Project_CheatSheet.Features.AWS
{
    using Amazon.S3.Model;
    using Common.Filters;

    using Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [Route("/aws")]
    public class AWSController : ApiController
    {
        private readonly IAwsService service;

        public AWSController(IAwsService service)
        {
            this.service = service;
        }

        [HttpPost("upload/{id}")]
        [ActionFilter]
        public async Task<string> Upload(Guid id, [FromForm(Name = "Data")] IFormFile file)
            => await service.UploadFile(id, file);

        [HttpGet("{id}")]
        [ActionFilter]
        public async Task<string> GetFile(Guid id) 
            => service.GetFile(id);
    }
}