using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

namespace _Project_CheatSheet.Tests.Comments
{
    using _Project_CheatSheet.Common.Exceptions;
    using _Project_CheatSheet.Common.UserService.Interfaces;
    using _Project_CheatSheet.Constants.GlobalConstants.Comment;
    using _Project_CheatSheet.Features.Comment.Models;
    using _Project_CheatSheet.Features.Comment.Services;
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using _Project_CheatSheet.Tests.Fixtures;
    using AutoMapper;

    using Constants.GlobalConstants.Resource;

    using Features.Comment.Interfaces;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    using Comment = Comment;

    public class CommentServiceTests : IClassFixture<ResourcesTestFixture>
    {
        private readonly ResourcesTestFixture fixture;

        public CommentServiceTests(ResourcesTestFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async Task CreateACommentShouldReturnCorrectMessageOnSuccess()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync();

            var commentModel = new InputCommentModel()
            {
                Content = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                ResourceId = findResource.Id.ToString(),
                UserId = "pesho"
            };

            var result=await fixture.CommentService.CreateAComment(commentModel);
            Assert.Equal(CommentMessages.OnSuccessfulPostComment,result);
        }

        [Fact]
        public async Task CreateACommentShouldThrowExceptionWhenInputCommentModelIsNull()
        {
            InputCommentModel nullCommentModel = null;

            await Assert.ThrowsAsync<CustomException>(() => fixture.CommentService.CreateAComment(nullCommentModel));
        }

        [Fact]
        public async Task CreateACommentShouldThrowExceptionIfResourceCannotBeFound()
        {
            var commentModel = new InputCommentModel()
            {
                Content = "asddasdasdasdasdasdas",
                ResourceId = Guid.NewGuid().ToString(),
                UserId = "qewrZXC"
            };

            await Assert.ThrowsAsync<CustomException>(()=>fixture.CommentService.CreateAComment(commentModel));
        }

        [Fact]
        public async Task EditCommentShouldReturnCorrectMessageOnSuccess()
        {
            var findComment=await fixture.DbContext.Comments.FirstOrDefaultAsync(c=>c.UserId=="pesho");

            var editCommentModel = new EditCommentModel()
            {
                Content = "qweweqeqwewqewqewqweq"
            };

            var result = await fixture.CommentService.EditComment(findComment.Id.ToString(), editCommentModel);

            Assert.Equal(CommentMessages.OnSuccessfulEditComment,result);
        }

        [Fact]
        public async Task EditCommentShouldThrowExceptionIfTheCommentDoesNotExist()
        {
            var editCommentModel = new EditCommentModel()
            {
                Content = "qweweqeqwewqewqewqweq"
            };

            await Assert.ThrowsAsync<ServiceException>(()=>fixture.CommentService.EditComment(Guid.NewGuid().ToString(),editCommentModel));
        }

        [Fact]
        public async Task EditCommentShouldThrowExceptionIfTheCommentHasBeenDeleted()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync();

            var comment = new Comment()
            {
                UserId = "pesho",
                Content = "aaaaaaaaaaaaaaaaa",
                IsDeleted = true,
                ResourceId = findResource.Id
            };

            await fixture.DbContext.Comments.AddAsync(comment);
            await fixture.DbContext.SaveChangesAsync();

            var commentToTryToEditWith = new EditCommentModel()
            {
                Content = "adsadasdasdasdasdasdas"
            };

            await Assert.ThrowsAsync<ServiceException>(() =>
                fixture.CommentService.EditComment(comment.Id.ToString(), commentToTryToEditWith));
        }

        [Fact]
        public async Task DeleteCommentShouldReturnCorrectMessageOnSuccess()
        {
            var findComment=await fixture.DbContext.Comments.Select(c=>new
            {
                c.Id,
                c.UserId
            }).FirstOrDefaultAsync(c=>c.UserId=="pesho");

            var result = await fixture.CommentService.DeleteComment(findComment.Id.ToString());

            Assert.Equal(CommentMessages.OnSuccessfulDeleteComment,result);
        }

        [Fact]
        public async Task DeleteCommentThrowsExceptionIfUserAttemptsToDeleteTheCommentFromAnotherUser()
        {
            var findComment=await fixture.DbContext.Comments.Select(c=>new
            {
                c.Id,
                c.UserId
            }).FirstOrDefaultAsync(c=>c.UserId!="pesho");

            Assert.ThrowsAsync<ServiceException>(() => fixture.CommentService.DeleteComment(findComment.Id.ToString()));
        }

        [Fact]
        public async Task DeleteCommentThrowsExceptionIfUserAttemptsToDeleteDeletedComment()
        {
            var findComment =
                await fixture.DbContext.Comments.FirstOrDefaultAsync(c => c.IsDeleted == true && c.UserId == "pesho");

            Assert.ThrowsAsync<ServiceException>(() => fixture.CommentService.DeleteComment(findComment.Id.ToString()));
        }

        [Fact]
        public async Task GetCommentsFromResourceShouldReturnCorrectAmountOfComment()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync(r=>r.UserId=="alice");

            var result = await fixture.CommentService.GetCommentsFromResource(findResource.Id.ToString());

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCommentsFroMResourceShouldReturn0IfIncorrectIdHasBeenPassed()
        {
            string randomId=Guid.NewGuid().ToString();

            var result = await fixture.CommentService.GetCommentsFromResource(randomId);

            Assert.Equal(0, result.Count());
        }
    }
}
      