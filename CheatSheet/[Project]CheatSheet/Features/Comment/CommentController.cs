﻿namespace _Project_CheatSheet.Features.Comment
{
    using Common.Filters;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/comment")]
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        [HttpPost("send")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> PostAComment(InputCommentModel comment)
            => await service.CreateAComment(comment);

        [HttpGet("get/{id}")]
        [ActionFilter()]
        public async Task<IEnumerable<CommentModel>> GetComments(string id)
            => await service.GetCommentsFromResource(id);

        [HttpPatch("edit/{id}")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> EditComment(string id, EditCommentModel comment)
            => await service.EditComment(id, comment);

        [HttpDelete("delete/{id}")]
        [ActionFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> DeleteComment(string id)
            => await service.DeleteComment(id);
    }
}