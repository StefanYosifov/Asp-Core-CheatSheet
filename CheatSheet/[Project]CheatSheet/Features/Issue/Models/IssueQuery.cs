namespace _Project_CheatSheet.Features.Issue.Models
{
    using Enums;

    public class IssueQuery
    {
        public int CurrentPage { get; set; } = 1;

        public string? SearchString { get; set; }

        public string TopicId { get; set; }

        public IssueSorting IssueSorting { get; set; }
    }
}