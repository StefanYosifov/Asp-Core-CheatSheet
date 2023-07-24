namespace _Project_CheatSheet.Features.Identity.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;

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