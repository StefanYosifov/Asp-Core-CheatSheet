namespace _Project_CheatSheet.Tests.Likes
{
    using _Project_CheatSheet.Tests.Fixtures;
    using Common.Exceptions;

    using Constants.GlobalConstants.Likes;

    using Features.Likes.Models;

    using Infrastructure.Data.SQL.Models;

    using Microsoft.EntityFrameworkCore;

    using Xunit;



    public class LikeTests:IClassFixture<ResourcesTestFixture>
    {
        private readonly ResourcesTestFixture fixture;

        public LikeTests(ResourcesTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task LikeACommentShouldWorkCorrectly()
        {
            var findComment = await fixture.DbContext.Comments.FirstOrDefaultAsync();

            var comment = new LikeCommentModel()
            {
                CommentId = findComment.Id.ToString()
            };
            var result = await fixture.LikeService.LikeAComment(comment);

            Assert.Equal(LikeMessages.OnSuccessfulLikedComment,result);
        }

        [Fact]
        public async Task LikeACommentShouldThrowExceptionIfTheCommentDoesNotExist()
        {
            var comment = new LikeCommentModel()
            {
                CommentId = Guid.NewGuid().ToString(),  
            };
            await Assert.ThrowsAsync<ServiceException>(()=> fixture.LikeService.LikeAComment(comment));
        }

        [Fact]
        public async Task LikeACommentShouldThrowExceptionIfTheCommentHasBeenLikedAlready()
        {
            var findComment = await fixture.DbContext.Comments.FirstOrDefaultAsync();

            var comment = new LikeCommentModel()
            {
                CommentId = findComment.Id.ToString()
            };

            await fixture.LikeService.LikeAComment(comment);

            await Assert.ThrowsAsync<ServiceException>(() => fixture.LikeService.LikeAComment(comment));
        }

        [Fact]
        public async Task RemoveLikeFromCommentShouldReturnSuccessMessageIfEverythingIsCorrect()
        {
            var findComment=await fixture.DbContext.Comments.Select(c=>new
            {
                c.Id,
                c.UserId
            }).FirstOrDefaultAsync(c=>c.UserId=="pesho");

            var comment = new LikeCommentModel()
            {
                CommentId = findComment.Id.ToString()
            };

            await fixture.LikeService.LikeAComment(comment);
            var result = await fixture.LikeService.RemoveLikeFromComment(comment);

            Assert.Equal(LikeMessages.OnSuccessfulRemovedComment,result);
        }

        [Fact]
        public async Task RemoveLikeFromCommentShouldThrowExceptionIfTheCommentHasNotBeenLiked()
        {
            var findComment=await fixture.DbContext.Comments.Select(c=>new
            {
                c.Id,
                c.UserId
            }).FirstOrDefaultAsync(c=>c.UserId=="pesho");

            var comment = new LikeCommentModel()
            {
                CommentId = findComment.Id.ToString()
            };

            await Assert.ThrowsAsync<ServiceException>(()=>fixture.LikeService.RemoveLikeFromComment(comment));
        }

        [Fact]
        public async Task LikeAResourceShouldReturnCorrectMessageOnSuccess()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync();

            var like = new LikeResourceModelAdd()
            {
                ResourceId = findResource.Id.ToString()
            };

            var result=await fixture.LikeService.LikeAResource(like);
            Assert.Equal(LikeMessages.OnSuccessfulLikedResource,result);
        }

        [Fact]
        public async Task LikeAResourceShouldThrowExceptionIfTheUserAttemptsToLikeAgain()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync();

            var like = new LikeResourceModelAdd()
            {
                ResourceId = findResource.Id.ToString()
            };

            await fixture.LikeService.LikeAResource(like);
            await Assert.ThrowsAsync<ServiceException>(() =>  fixture.LikeService.LikeAResource(like));
        }

        [Fact]
        public async Task RemoveLikeFromResourceShouldReturnCorrectMessageOnSuccess()
        {
            var findResource = await fixture.DbContext.Resources.FirstOrDefaultAsync();

            var like = new LikeResourceModelAdd()
            {
                ResourceId = findResource.Id.ToString()
            };

            await fixture.LikeService.LikeAResource(like);

            var likeResource = new LikeResourceModel()
            {
                HasLiked = true,
                ResourceId = findResource.Id.ToString(),
                TotalLikes = 5
            };

            var result = await fixture.LikeService.RemoveLikeFromResource(likeResource);
            Assert.Equal(LikeMessages.OnSuccesfulRemoveLikeResource,result);
        }

        [Fact]
        public async Task RemoveLikeFromResourceShouldThrowExceptionIfTheLikeDoesNotExist()
        {
            var likeResource = new LikeResourceModel()
            {
                HasLiked = true,
                ResourceId = Guid.NewGuid().ToString(),
                TotalLikes = 5
            };

            await Assert.ThrowsAsync<ServiceException>(()=> fixture.LikeService.RemoveLikeFromResource(likeResource));
        }
        
        [Fact]
        public async Task RemoveLikeFromResourceShouldThrowExceptionIfAnotherUserTriesToDelete()
        {
            var findResource=await fixture.DbContext.Resources.FirstOrDefaultAsync();
            var resourceLike = new ResourceLike()
            {
                ResourceId = findResource.Id,
                UserId = "admin321312",
                CreatedAt = DateTime.UtcNow
            };

            await fixture.DbContext.ResourceLikes.AddRangeAsync(resourceLike);
            await fixture.DbContext.SaveChangesAsync();

            var likeToAttemptDeleteWith = new LikeResourceModel()
            {
                HasLiked = true,
                ResourceId = findResource.Id.ToString(),
                TotalLikes = 5
            };


            await Assert.ThrowsAsync<ServiceException>(() => fixture.LikeService.RemoveLikeFromResource(likeToAttemptDeleteWith));
        }

        [Fact]
        public async Task GetResourceLikeCountShouldReturnCorrectAmountOfLikes()
        {
            var findResource=await fixture.DbContext.Resources.FirstOrDefaultAsync();
            var resourceLike = new ResourceLike()
            {
                ResourceId = findResource.Id,
                UserId = "admin321312",
                CreatedAt = DateTime.UtcNow
            };

            await fixture.DbContext.ResourceLikes.AddRangeAsync(resourceLike);
            await fixture.DbContext.SaveChangesAsync();

            var result = fixture.LikeService.GetResourceLikesCount(findResource.Id.ToString());
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetCommentLikeCountShouldReturnCorrectAmountOfLikes()
        {
            var findResource=await fixture.DbContext.Resources.FirstOrDefaultAsync();
            var comment = new Comment()
            {
                Content = "This is a very lengthy content!!",
                UserId = "pesho",
                ResourceId = findResource!.Id,
            };

            await fixture.DbContext.Comments.AddAsync(comment);
            await fixture.DbContext.SaveChangesAsync();

            var commentLike = new CommentLike()
            {
                UserId = "pesho",
                CommentId = comment.Id,
            };

            await fixture.DbContext.CommentLikes.AddAsync(commentLike);
            await fixture.DbContext.SaveChangesAsync();


            var likeCommentModelToAttemptToGetLikesWith = new LikeCommentModel()
            {
                CommentId = comment.Id.ToString()
            };

            var result = fixture.LikeService.GetCommentLikesCount(likeCommentModelToAttemptToGetLikesWith);
            Assert.Equal(1, result);
        }
    }
}
