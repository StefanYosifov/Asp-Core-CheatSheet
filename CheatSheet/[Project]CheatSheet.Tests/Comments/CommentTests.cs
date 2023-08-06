using _Project_CheatSheet.Infrastructure.Data.SQL.Models;

namespace _Project_CheatSheet.Tests.Comments
{
    using _Project_CheatSheet.Common.Exceptions;
    using _Project_CheatSheet.Common.UserService.Interfaces;
    using _Project_CheatSheet.Constants.GlobalConstants.Comment;
    using _Project_CheatSheet.Features.Comment.Models;
    using _Project_CheatSheet.Features.Comment.Services;
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using AutoMapper;

    using Features.Comment.Interfaces;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    using Comment = Comment;

    public class CommentServiceTests
    {
        private ICommentService _commentService;
        private CheatSheetDbContext _dbContext;
        private Mock<ICurrentUser> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;


        Resource globalResource=new Resource()
        {
            UserId = "pesho",
            Content = "This is a very nice comment isn't it?",
            Id = Guid.NewGuid(),
            IsPublic = true,
            Title = "THE BEST TITLE TO EVER EXIST",
            ImageUrl = "https:/snimki.bg",
            CreatedBy = "pesho",
            CreatedOn = DateTime.UtcNow,
            UpdatedBy = "pesho",
            UpdatedOn = DateTime.UtcNow,
        };


        public CommentServiceTests()
        {
            // Set up the in-memory database with IHttpContextAccessor mock
            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;


            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());
            
            _dbContext = new CheatSheetDbContext(options, httpContextAccessorMock.Object);

            _currentUserServiceMock = new Mock<ICurrentUser>();
            _mapperMock = new Mock<IMapper>();
            _commentService = new CommentService(
                _dbContext,
                _currentUserServiceMock.Object,
                _mapperMock.Object);


            _dbContext.Add(globalResource);
            _dbContext.SaveChangesAsync();
        }

        // Test for CreateAComment method
        [Fact]
        public async Task CreateAComment_ShouldThrowServiceException_WhenInputCommentModelIsNull()
        {
            // Arrange
            InputCommentModel nullCommentModel = null;

            // Act & Assert
            await Assert.ThrowsAsync<ServiceException>(() => _commentService.CreateAComment(nullCommentModel));
        }

        [Fact]
        public async Task CreateAComment_ShouldThrowServiceException_WhenResourceDoesNotExist()
        {
            // Arrange
            var inputCommentModel = new InputCommentModel
            {
                ResourceId = Guid.NewGuid().ToString(),
                Content = "This is a test comment.ISNT IT THE BEST THING EVER TO EXISTS?"
            };


            // Act & Assert
            await Assert.ThrowsAsync<ServiceException>(() => _commentService.CreateAComment(inputCommentModel));
        }

        [Fact]
        public async Task CreateAComment_ShouldReturnSuccessMessage_WhenCommentIsCreated()
        {
            // Arrange
            var validResourceId = this.globalResource.Id;
            var inputCommentModel = new InputCommentModel
            {
                ResourceId = validResourceId.ToString(),
                Content = "This is a test comment."
            };

            var validUser = new User
            {
                Id = Guid.NewGuid().ToString(), // Assuming the current user has an Id
                UserName = "peshoBe"
            };


            _currentUserServiceMock.Setup(mock => mock.GetUserId())
                .Returns(validUser.Id);

            var resource = new Resource
            {
                Content = "This is a random content",
                ImageUrl = "This is a very nice image url!!!",
                Title = "A NICE TITLE TOO HUH",
                UserId = validUser.Id
            };
            _dbContext.Resources.Add(resource);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _commentService.CreateAComment(inputCommentModel);

            // Assert
            Assert.Equal(CommentMessages.OnSuccessfulPostComment, result);

            // Verify that the comment is added to the database
            var commentInDb = await _dbContext.Comments.FirstOrDefaultAsync(c => c.UserId == validUser.Id);
            Assert.NotNull(commentInDb);
            Assert.Equal(validUser.Id, commentInDb.UserId);
            Assert.Equal(inputCommentModel.Content, commentInDb.Content);
        }

        [Fact]
        [InlineData()]
        public async Task DeleteCommentShouldThrowExceptionIfCommentIsDeletedIsNullBelongsToDifferentUserOrDoesNotExist()
        {
            Comment dbComment = new Comment()
            {
                UserId = "pesho",
                Content = "This is a very nice Content, isn't it?",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "pesho",
                UpdatedOn = DateTime.UtcNow,
                UpdatedBy = "pesho",
                ResourceId = globalResource.Id,
            };

            Comment dbCommentDeleted = new Comment()
            {
                UserId = "peshoQdeRiba",
                Content = "This is a very nice Content, isn't it?",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "pesho",
                UpdatedOn = DateTime.UtcNow,
                UpdatedBy = "pesho",
                ResourceId = globalResource.Id,
                IsDeleted = true
            };


            await _dbContext.Comments.AddAsync(dbComment);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Comments.AddAsync(dbCommentDeleted);
            await _dbContext.SaveChangesAsync();

            _currentUserServiceMock.Setup(mock => mock.GetUserId())
                .Returns("pesho123");

            Assert.ThrowsAsync<ServiceException>(() => _commentService.DeleteComment($"Invalid{dbComment.Id}"));
            Assert.ThrowsAsync<ServiceException>(() => _commentService.DeleteComment($"{dbCommentDeleted.Id}"));
            Assert.ThrowsAsync<ServiceException>(() => _commentService.DeleteComment($"{dbComment.Id}"));
        }

        [Fact]
        public async Task DeleteCommentShouldReturnMessageIfSuccessful()
        {
            Comment dbCommentDeleted = new Comment()
            {
                UserId = "123456",
                Content = "This is a very nice Content, isn't it?",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "pesho",
                UpdatedOn = DateTime.UtcNow,
                UpdatedBy = "pesho",
                ResourceId = globalResource.Id,
                IsDeleted = false
            };

            await _dbContext.Comments.AddAsync(dbCommentDeleted);
            await _dbContext.SaveChangesAsync();

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext!.User.Identity.Name).Returns(It.IsAny<string>());

            _currentUserServiceMock.Setup(mock => mock.GetUserId())
                .Returns("123456");

           var result=_commentService.DeleteComment(dbCommentDeleted.Id.ToString());
            

            Assert.Equal(CommentMessages.OnSuccessfulDeleteComment,result.Result);
         
        }


    }
}
