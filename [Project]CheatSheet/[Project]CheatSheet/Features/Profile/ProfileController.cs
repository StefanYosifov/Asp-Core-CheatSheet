namespace _Project_CheatSheet.Features.Profile
{
    using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Profile;
    using Common.Filters;
    using Common.UserService.Interfaces;
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
        [ActionFilter()]
        public async Task<ProfileModel> GetProfileData(string id)
            => await service.GetProfileData(id);

        [Authorize]
        [HttpPatch("update")]
        [ActionFilter("", ProfileMessages.OnUnsuccessfulUserChange)]
        public async Task<UserEditModel> UpdateProfileData(UserEditModel userModel)
            => await service.EditProfileData(userModel);
    }
}