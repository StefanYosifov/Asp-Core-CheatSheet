namespace _Project_CheatSheet.Features.Videos
{
    using Common.Filters;
    using Common.GlobalConstants.Videos;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("/videos")]
    public class VideoController : ApiController
    {
        private readonly IVideoService service;
        private readonly IConfiguration configuration;

        public VideoController(
            IVideoService service, 
            IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }

        [HttpGet("id/{videoId}")]
        [ActionFilter("", VideoMessages.OnUnsuccessfulGetVideoId)]
        [ExceptionHandlingActionFilter]
        public async Task<string?> GetVideoId(Guid videoId)
            => await service.GetVideoId(videoId);

    }
}

