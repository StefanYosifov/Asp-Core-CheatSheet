namespace _Project_CheatSheet.Features.Profile.Services
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using AutoMapper;
    using Common.UserService.Interfaces;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ProfileService : IProfileService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public ProfileService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService,
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public async Task<ProfileUserEditModel> EditProfileData(ProfileUserEditModel profileUserEdit)
        {
            var currentUser = await currentUserService.GetUser();
            context.Entry(currentUser).CurrentValues.SetValues(profileUserEdit);
            try
            {
                await context.SaveChangesAsync();
                return profileUserEdit;
            }
            catch (DbUpdateException)
            {
                return null!;
            }
        }

        public async Task<ProfileModel> GetProfileData(string userId)
        {
            var postCount = await context.Resources
                .CountAsync(p => p.UserId == userId);

            var likedResourceIds = await context.ResourceLikes
                .Where(rl => rl.UserId == userId)
                .Select(rl => rl.ResourceId)
                .ToArrayAsync();

            var totalResourceLikes = await context.ResourceLikes
                .Include(rl => rl.Resource)
                .Where(rl => rl.Resource.UserId == userId)
                .Select(rl => rl.ResourceId)
                .CountAsync();


            var totalLikedComments = await context.CommentLikes
                .Where(cl => cl.Comment.UserId == userId)
                .CountAsync();

            var findUser = await context.Users.FindAsync(userId);
            var user = mapper.Map<ProfileUserModel>(findUser);

            var profileModel = new ProfileModel
            {
                PostCount = postCount,
                ResourceLikes = totalResourceLikes,
                CommentLikes = totalLikedComments,
                ProfileUser = user
            };

            return profileModel;
        }
    }
}