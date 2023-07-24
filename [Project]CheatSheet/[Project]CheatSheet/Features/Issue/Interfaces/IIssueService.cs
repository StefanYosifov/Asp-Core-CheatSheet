namespace _Project_CheatSheet.Features.Issue.Interfaces
{
    using Models;

    public interface IIssueService
    {
        public Task<ICollection<IssueRespondModel>> GetIssues(IssueQuery? query);

        public Task<ICollection<IssueCategoryModel>> GetIssuesCategories();

        //Maybe admin logic
        public Task<string> WithdrawIssue(string issueId);

        public Task<ICollection<IssueRespondModel>> GetIssuesByTopicId(string topicId);

        public Task<string> CreateIssue(IssueRequestModel issue);
    }
}