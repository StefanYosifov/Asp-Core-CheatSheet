namespace _Project_CheatSheet.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.User;

    public class LoginModel
    {
        [Required]
        [StringLength(UserConstants.NameMaxLength, MinimumLength = UserConstants.NameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.PasswordMaxLength, MinimumLength = UserConstants.PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}