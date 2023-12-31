﻿namespace _Project_CheatSheet.Features.Videos.Services
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using Common.Caching;
    using Common.Exceptions;
    using Common.UserService.Interfaces;

    using Constants.CachingConstants;
    using Constants.GlobalConstants.Course;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;

    public class VideoService : IVideoService
    {
        private readonly IMemoryCache cache;
        private readonly ICacheService cacheService;
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;

        public VideoService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService,
            IMemoryCache cache,
            ICacheService cacheService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.cache = cache;
            this.cacheService = cacheService;
        }

        public async Task<string?> GetVideoId(Guid topicId)
        {
            var userId = currentUserService.GetUserId();
            var cacheKey = $"videos_{userId}_{topicId}";

            if (cache.TryGetValue(cacheKey, out string? cachedVideo))
            {
                return cachedVideo;
            }

            var findCourse = await context.Courses
                .Include(c=>c.Topics)
                .ThenInclude(v=>v.Video)
                .Where(c => c.Topics.Any(t => t.Id == topicId))
                .FirstOrDefaultAsync();

            CustomException.ThrowIfNull(findCourse, CourseMessages.CourseNotFound);

            var userNotInCourse = await context.UserCourses.AllAsync(uc =>
                uc.UserId != userId && uc.CourseId.ToString() != findCourse.Id.ToString());

            if (userNotInCourse)
            {
                throw new ServiceException(CourseMessages.UserNotInCourse);
            }

            var youtubeVideoUrl = findCourse.Topics
                .Select(t => t.Video.VideoUrl.Split("=")[1])
                .FirstOrDefault();

            cacheService.SetCache(cacheKey, youtubeVideoUrl, CachingConstants.Lessons.YoutubeUrl);

            return youtubeVideoUrl;
        }
    }
}