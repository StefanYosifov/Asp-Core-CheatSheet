namespace _Project_CheatSheet.Features.Profile.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.User;

    public class ProfileUserEditModel
    {
        public string? ProfilePictureUrl { get; set; }

        [StringLength(UserConstants.DescriptionMaxLength, MinimumLength = UserConstants.DescriptionMinLength)]
        public string? ProfileDescription { get; set; }

        [StringLength(UserConstants.BackGroundImageMaxLength, MinimumLength = UserConstants.BackGroundImageMinLength)]
        public string? ProfileBackground { get; set; }

        [StringLength(UserConstants.EducationMaxLength, MinimumLength = UserConstants.EducationMinLength)]
        public string? UserEducation { get; set; }

        [StringLength(UserConstants.JobMaxLength, MinimumLength = UserConstants.JobMinLength)]
        public string? UserJob { get; set; }
    }
}