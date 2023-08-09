namespace _Project_CheatSheet.Features.Profile
{
    using Common.Filters;
    using Common.UserService.Interfaces;

    using Constants.GlobalConstants.Profile;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;


    [Route("/profile")]
    public class ProfileController : ApiController
    {
        private readonly ICurrentUser currentUser;

        private readonly IProfileService service;

        public ProfileController(
            IProfileService service,
            ICurrentUser currentUser)
        {
            this.service = service;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet("myUser")]
        public ActionResult GetMyUserId()
        {
            var userId = currentUser.GetUserId();
            return Ok(userId);
        }


        [Authorize]
        [HttpGet("{id}")]
        [ActionHandlingFilter()]
        public async Task<ProfileModel> GetProfileData(string id)
            => await service.GetProfileData(id);

        [Authorize]
        [HttpPatch("update")]
        [ActionHandlingFilter("", ProfileMessages.OnUnsuccessfulUserChange)]
        public async Task<ProfileUserEditModel> UpdateProfileData(ProfileUserEditModel profileUserModel)
            => await service.EditProfileData(profileUserModel);
    }
}