namespace _Project_CheatSheet.Features.Issue.Models
{
    using System.ComponentModel.DataAnnotations;

    public class IssueCategoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string LocationIssue { get; set; }
    }
}