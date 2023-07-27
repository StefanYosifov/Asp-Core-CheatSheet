namespace _Project_CheatSheet.Features.Profile.Interfaces
{
    using Models;

    public interface IProfileService
    {
        public Task<ProfileModel> GetProfileData(string id);

        public Task<UserEditModel> EditProfileData(UserEditModel user);
    }
}