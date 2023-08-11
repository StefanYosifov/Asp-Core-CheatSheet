namespace _Project_CheatSheet.Features.Statistics
{
    using Common.Filters_and_Attributes.Filters;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/statistics")]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService service;

        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        [ActionHandlingFilter("", "", StatusCodes.Status403Forbidden)]
        public StatisticsModel GetHomePageStatistics()
            => service.GetAllStatistics();

        [HttpGet("course")]
        [ActionHandlingFilter("","",StatusCodes.Status403Forbidden)]
        public StatisticsCourseModel GetCoursePageStatistics()
            =>service.GetStatisticsCourse();
    }
}