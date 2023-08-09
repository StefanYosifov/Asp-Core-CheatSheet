namespace _Project_CheatSheet.Features.Comment.Services
{
    using System.Net;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common.Exceptions;
    using Common.UserService.Interfaces;

    using Constants.GlobalConstants.Comment;
    using Constants.GlobalConstants.Resource;

    using Infrastructure.Data.SQL;
    using Infrastructure.Data.SQL.Models;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Models;

    public class CommentService : ICommentService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public CommentService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService,
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public async Task<string> CreateAComment(CommentInputModel comment)
        {
            CustomException.ThrowIfNull(comment, CommentMessages.OnEmptyComment);

            comment.Content = WebUtility.HtmlDecode(comment.Content);

            var resource = await GetResource(comment.ResourceId.ToLower());
            CustomException.ThrowIfNull(resource, CommentMessages.OnUnsuccessfulPostComment);

            var userId = currentUserService.GetUserId();

            var dbComment = new Comment
            {
                UserId = userId,
                Content = comment.Content,
                ResourceId = Guid.Parse(comment.ResourceId)
            };

            await context.Comments.AddAsync(dbComment);
            await context.SaveChangesAsync();
            return CommentMessages.OnSuccessfulPostComment;
        }

        public async Task<string> EditComment(string id, CommentEditModel model)
        {
            var currentUserId = currentUserService.GetUserId();

            var comment = await context.Comments
                .FindAsync(Guid.Parse(id));

            if (comment == null || comment.UserId != currentUserId || comment.IsDeleted)
            {
                throw new ServiceException(ResourceMessages.NoPermission);
            }

            context.Entry(comment).CurrentValues.SetValues(model);
            await context.SaveChangesAsync();
            return CommentMessages.OnSuccessfulEditComment;
        }

        public async Task<string> DeleteComment(string id)
        {
            var userId = currentUserService.GetUserId();

            var comment = await context.Comments
                .FindAsync(Guid.Parse(id));

            if (comment == null || comment.UserId != userId || comment.IsDeleted)
            {
                throw new ServiceException(CommentMessages.OnUnsuccessfulDeleteComment);
            }

            context.Remove(comment);
            await context.SaveChangesAsync();
            return CommentMessages.OnSuccessfulDeleteComment;
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId)
        {
            var userId = currentUserService.GetUserId();


            IEnumerable<CommentModel> comments = await context.Comments
                .OrderBy(c => c.CreatedOn)
                .ProjectTo<CommentModel>(mapper.ConfigurationProvider)
                .Where(c => c.ResourceId == resourceId).ToArrayAsync();

            foreach (var comment in comments)
            {
                bool hasLiked=await context.CommentLikes
                    .AnyAsync(cl => cl.CommentId.ToString() == comment.Id && cl.UserId == userId);
                comment.HasLiked = hasLiked;
            }

            return comments;
        }

        private async Task<Resource?> GetResource(string resourceId)
        {
            var resource = await context.Resources
                .FindAsync(Guid.Parse(resourceId));

            return resource;
        }
    }
}