namespace _Project_CheatSheet.Features.Topics
{
    using Common.Filters;

    using Constants.GlobalConstants.Topic;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/course/topic")]
    public class TopicController : ApiController
    {
        private readonly ITopicService service;

        public TopicController(
            ITopicService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [ActionFilter("", TopicMessages.OnUnsuccessful)]
        public async Task<TopicRespondModel?> GetTopic(string id)
            => await service.GetTopic(id);

        [HttpGet("all/{id}")]
        public async Task<IEnumerable<TopicRespondModel>> GetAllTopics(string id)
            => await service.GetAllTopics(id);
    }
}