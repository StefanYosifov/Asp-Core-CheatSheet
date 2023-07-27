﻿namespace _Project_CheatSheet.Features.Issue.Models
{
    using Infrastructure.Data.GlobalConstants.Issue;
    using System.ComponentModel.DataAnnotations;

    public class IssueRequestModel
    {
        public int Id { get; set; }

        [Required]
        public int IssueCategoryId { get; set; }

        [Required]
        [StringLength(IssueConstants.IssueTitleMaxLength, MinimumLength = IssueConstants.IssueTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(IssueConstants.IssueDescriptionMaxLength, MinimumLength = IssueConstants.IssueDescriptionMinLength)]
        public string Description { get; set; }

        public Guid TopicId { get; set; }
    }
}