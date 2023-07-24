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

        public VideoController(IVideoService service)
        {
            this.service = service;
        }

        [HttpGet("id/{videoId}")]
        [ActionFilter("", VideoMessages.OnUnsuccessfulGetVideoId)]
        public async Task<string> GetVideoId(string videoId)
            => await service.GetVideoId(videoId.ToLower());
    }
}
