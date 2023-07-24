namespace _Project_CheatSheet.Infrastructure.Data.Models;

using Base;
using GlobalConstants.Issue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Issue : DeletableEntity
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(IssueConstants.IssueTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(IssueConstants.IssueDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required][ForeignKey(nameof(User))] public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(CategoryIssue))]
    public int? CategoryIssueId { get; set; }

    public CategoryIssue? CategoryIssue { get; set; }

    [Required][ForeignKey(nameof(Topic))] public Guid TopicId { get; set; }

    public virtual Topic Topic { get; set; }
}