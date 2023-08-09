namespace _Project_CheatSheet.Area.AdminServices.Models.Issues
{
    using Features.Issue.Enums;

    public class IssueQueryModel
    {

        public string? Search { get; set; }

        public int PageNumber { get; set; }

        public string? SelectedCourseName { get; set; }

        public IssueSorting Sorting { get; set; }

    }
}
