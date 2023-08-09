namespace _Project_CheatSheet.Area.AdminServices.Models.Issues
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Issue;
    using Constants.GlobalConstants.Topic;

    public class GetIssuesAdminModel
    {

        [Required]
        public int Id { get; set; } 

        [Required]
        [StringLength(IssueConstants.IssueTitleMaxLength, MinimumLength = IssueConstants.IssueTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(IssueConstants.IssueDescriptionMaxLength, MinimumLength = IssueConstants.IssueDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(TopicConstants.NameMaxLength)]
        public string TopicName { get; set; } = null!;

        [Required]
        public string LocationIssue { get; set; } = null!;


    }
}
