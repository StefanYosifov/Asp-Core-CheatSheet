namespace _Project_CheatSheet.Features.Issue.Models;

using System.ComponentModel.DataAnnotations;

using Constants.GlobalConstants.Issue;

public class IssueRespondModel
{
    public int Id { get; set; }

    [Required] public string LocationIssue { get; set; } = null!;

    [Required]
    [StringLength(IssueConstants.IssueTitleMaxLength, MinimumLength = IssueConstants.IssueTitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(IssueConstants.IssueDescriptionMaxLength, MinimumLength = IssueConstants.IssueDescriptionMinLength)]
    public string Description { get; set; } = null!;
}