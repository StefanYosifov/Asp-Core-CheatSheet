namespace _Project_CheatSheet.Features.Profile.Models
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Profile;
    using System.ComponentModel.DataAnnotations;

    public class ProfileModel
    {
        [Range(ProfileConstants.MinValue, ProfileConstants.MaxValue)]
        public int PostCount { get; set; }

        [Range(ProfileConstants.MinValue, ProfileConstants.MaxValue)]
        public int ResourceLikes { get; set; }

        [Range(ProfileConstants.MinValue, ProfileConstants.MaxValue)]
        public int CommentLikes { get; set; }

        [Required] public virtual UserModel User { get; set; } = null!;
    }
}