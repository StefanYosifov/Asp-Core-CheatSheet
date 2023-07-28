namespace _Project_CheatSheet.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.User;

    public class RegisterModel
    {
        [Required]
        [StringLength(UserConstants.NameMaxLength, MinimumLength = UserConstants.NameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.EmailMaxLength, MinimumLength = UserConstants.EmailMinLength)]
        [EmailAddress]

        public string Email { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.PasswordMaxLength, MinimumLength = UserConstants.PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}