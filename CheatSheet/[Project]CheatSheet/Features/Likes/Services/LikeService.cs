﻿namespace _Project_CheatSheet.Features.Likes.Services
{
    using AutoMapper;
    using Common.Exceptions;
    using Common.UserService.Interfaces;
    using Constants.GlobalConstants.Likes;
    using Infrastructure.Data.SQL;
    using Infrastructure.Data.SQL.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LikeService : ILikeService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public LikeService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService,
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public int GetCommentLikesCount(LikeCommentModel commentModel)
        {
            return context.CommentLikes
                .Count(c => c.CommentId.ToString() == commentModel.CommentId);
        }

        public async Task<string> LikeAComment(LikeCommentModel likeComment)
        {
            var userId = currentUserService.GetUserId();
            var findComment = await context.Comments
                .FindAsync(Guid.Parse(likeComment.CommentId));

            if (findComment == null || findComment.CommentLikes.Any(cl => cl.UserId == userId))
            {
                throw new ServiceException(LikeMessages.FailedLikedResource);
            }

            var commentLike = new CommentLike
            {
                UserId = userId,
                CommentId = Guid.Parse(likeComment.CommentId),
                CreatedOn = DateTime.Now
            };

            await context.CommentLikes.AddAsync(commentLike);
            await context.SaveChangesAsync();
            return LikeMessages.SuccessfulLikedComment;
        }

        public async Task<string> RemoveLikeFromComment(LikeCommentModel likeComment)
        {
            var userId = currentUserService.GetUserId();

            var commentLike =
                await context.CommentLikes
                    .FirstOrDefaultAsync(c => c.CommentId.ToString() == likeComment.CommentId);

            if (commentLike == null)
            {
                throw new ServiceException(LikeMessages.FailedRemoveComment);
            }

            if (commentLike.UserId != userId)
            {
                throw new ServiceException(LikeMessages.FailedUserDoNoMatch);
            }

            context.Remove(commentLike);
            await context.SaveChangesAsync();
            return LikeMessages.SuccessfulRemovedComment;
        }

        public int GetResourceLikesCount(string id)
        {
            return context.ResourceLikes
                .Count(rl => rl.ResourceId.ToString() == id);
        }

        public async Task<string> LikeAResource(LikeResourceModelAdd likeResource)
        {
            var userId = currentUserService.GetUserId();

            var hasLikedAlready = context.ResourceLikes
                .Any(rl => rl.UserId == userId
                           && rl.ResourceId.ToString() ==
                           likeResource.ResourceId);

            if (hasLikedAlready)
            {
                throw new ServiceException(LikeMessages.FailedLikedResource);
            }

            var likeResult = mapper.Map<ResourceLike>(likeResource);
            likeResult.UserId = userId;

            await context.ResourceLikes.AddAsync(likeResult);
            await context.SaveChangesAsync();
            return LikeMessages.SuccessfulLikedResource;
        }

        public async Task<string> RemoveLikeFromResource(LikeResourceModel likeResource)
        {
            var userId = currentUserService.GetUserId();
            var resourceLike =
                await context.ResourceLikes
                    .FirstOrDefaultAsync(rl => rl.ResourceId.ToString() == likeResource.ResourceId);

            if (resourceLike == null)
            {
                throw new ServiceException(LikeMessages.FailedRemoveResource);
            }

            if (resourceLike.UserId != userId)
            {
                throw new ServiceException(LikeMessages.FailedUserDoNoMatch);
            }

            context.Remove(resourceLike);
            await context.SaveChangesAsync();
            return LikeMessages.SuccessfulRemoveLikeResource;
        }

        public async Task<IEnumerable<LikeResourceModel>> ResourcesLikes()
        {
            var userId = currentUserService.GetUserId();
            var resourceLikes = await context.ResourceLikes
                .Include(rl => rl.User)
                .Select(rl => new LikeResourceModel
                {
                    ResourceId = rl.ResourceId.ToString(),
                    HasLiked = rl.Resource.ResourceLikes.Any(u => u.UserId == userId),
                    TotalLikes = context.ResourceLikes.Count(x => x.ResourceId == rl.ResourceId)
                })
                .Distinct()
                .ToArrayAsync();
            return resourceLikes;
        }
    }
}