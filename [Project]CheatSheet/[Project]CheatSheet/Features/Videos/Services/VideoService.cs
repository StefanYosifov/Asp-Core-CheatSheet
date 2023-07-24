namespace _Project_CheatSheet.Features.Videos.Services
{
    using Common.UserService.Interfaces;
    using Infrastructure.Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class VideoService : IVideoService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;

        public VideoService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<string> GetVideoId(string videoId)
        {
            var userId = currentUserService.GetUserId();
            var getCourseId = await context.Courses
                .FirstOrDefaultAsync(c => c.Topics.Any(t => t.VideoId.ToString() == videoId));

            if (!await context.UserCourses.AnyAsync(uc => uc.CourseId == getCourseId.Id && uc.UserId == userId))
            {
                return null;
            }

            var youtubeVideoUrl =
                await context.Videos.FirstOrDefaultAsync(v => v.Id.ToString() == videoId);

            return youtubeVideoUrl?.VideoUrl.Split("=")[1];
        }
    }
}