﻿namespace _Project_CheatSheet.Features.Profile.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.User;

    public class ProfileUserModel
    {
        [Required] public string UserName { get; set; } = null!;

        [Required] public string UserId { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        [MaxLength(UserConstants.DescriptionMaxLength)]
        public string? UserProfileDescription { get; set; }

        [MaxLength(UserConstants.BackGroundImageMaxLength)]
        public string? UserProfileBackground { get; set; }

        [MaxLength(UserConstants.EducationMaxLength)]
        public string? UserEducation { get; set; }

        [MaxLength(UserConstants.JobMaxLength)]
        public string? UserJob { get; set; }
    }
}