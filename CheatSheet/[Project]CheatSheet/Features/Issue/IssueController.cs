namespace _Project_CheatSheet.Features.Issue
{
    using Common.Filters_and_Attributes.Filters;

    using Models;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("/issue")]
    public class IssueController : ApiController
    {
        private readonly IIssueService service;

        public IssueController(IIssueService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        [ActionHandlingFilter()]
        public async Task<ICollection<IssueRespondModel>> GetIssues([FromQuery] IssueQuery? query)
            => await service.GetIssues(query);

        [HttpPost("add")]
        [ActionHandlingFilter()]
        [ExceptionHandlingActionFilter()]
        public async Task<string> AddIssue(IssueRequestModel createdIssue)
            => await service.CreateIssue(createdIssue);

        [HttpGet("categories")]
        [ActionHandlingFilter()]
        public async Task<ICollection<IssueCategoryModel>> GetCategoryIssues()
            => await service.GetIssuesCategories();
    }
}