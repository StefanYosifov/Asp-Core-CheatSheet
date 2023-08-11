namespace _Project_CheatSheet.Tests.Issues
{
    using Features.Issue.Enums;
    using Features.Issue.Models;

    using Fixtures;

    using Microsoft.EntityFrameworkCore;

    using Xunit;


    public class IssueTests:IClassFixture<CoursesTestFixture>
    {

        private readonly CoursesTestFixture fixture;

        public IssueTests(CoursesTestFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async Task GetIssuesShouldReturnACollectionOfIssues()
        {
            var findTopic = await fixture.DbContext.Topics.Where(t => t.TopicIssues.Count > 0).FirstOrDefaultAsync();
            var issues = await fixture.DbContext.Issues.ToArrayAsync();
            var issueQuery = new IssueQuery()
            {
                CurrentPage = 1,
                IssueSorting = IssueSorting.Newest,
                TopicId = findTopic.Id.ToString(),
            };

            var result=await fixture.IssueService.GetIssues(issueQuery);

            Assert.NotEmpty(result);
        }
    }
}
