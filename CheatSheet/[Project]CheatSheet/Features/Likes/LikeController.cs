﻿namespace _Project_CheatSheet.Features.Likes
{
    using Common.Filters_and_Attributes.Filters;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/like")]
    public class LikeController : ApiController
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpGet("comment/{id}")]
        public int CommentLikesCount(LikeCommentModel likeComment)
            => likeService.GetCommentLikesCount(likeComment);

        [HttpPost("comment/like")]
        [ActionHandlingFilter()]
        [ExceptionHandlingActionFilter]
        public async Task<string> LikeAComment(LikeCommentModel commentModel)
            => await likeService.LikeAComment(commentModel);

        [HttpPost("comment/remove")]
        [ActionHandlingFilter()]
        [ExceptionHandlingActionFilter]
        public async Task<string> RemoveLikeFromComment(LikeCommentModel commentModel)
            => await likeService.RemoveLikeFromComment(commentModel);

        [HttpGet("resource/{id}")]
        [ActionHandlingFilter()]
        public int GetResourceLikes(string id)
            => likeService.GetResourceLikesCount(id);

        [HttpPost("resource/like/{id}")]
        [ActionHandlingFilter()]
        [ExceptionHandlingActionFilter]
        public async Task<string> LikeAResource(LikeResourceModelAdd likeResource)
            => await likeService.LikeAResource(likeResource);

        [HttpPost("resource/remove/{id}")]
        [ActionHandlingFilter()]
        [ExceptionHandlingActionFilter]
        public async Task<string> RemoveLikeResource(LikeResourceModel likeResource)
            => await likeService.RemoveLikeFromResource(likeResource);

        [HttpGet("resource/all")]
        [ActionHandlingFilter()]
        public async Task<IEnumerable<LikeResourceModel>> GetAllResourceLikes()
            => await likeService.ResourcesLikes();
    }
}