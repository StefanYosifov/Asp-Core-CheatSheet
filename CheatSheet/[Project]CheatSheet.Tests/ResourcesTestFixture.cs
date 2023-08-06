namespace _Project_CheatSheet.Tests
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
    using AutoMapper;
    using Common.Mapping;
    using Common.UserService.Interfaces;
    using Features.Comment.Interfaces;
    using Features.Comment.Services;
    using Features.Resources.Models;
    using Features.Resources.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using IResourceService = Features.Resources.Interfaces.IResourceService;

    public class ResourcesTestFixture : IDisposable
    {
        protected ICommentService CommentService { get; private set; }
        public IResourceService ResourceService { get; private set; }

        public CheatSheetDbContext DbContext { get; private set; }

        private List<Resource> resources = new List<Resource>();

        private List<Comment> comments = new List<Comment>();

        private List<ResourceLike> resourceLikes = new List<ResourceLike>();

        private List<Category> categories=new List<Category>();
        private static IMapper _mapper;


        public ResourcesTestFixture()
        {
            var options = new DbContextOptionsBuilder<CheatSheetDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());


            DbContext = new CheatSheetDbContext(options, httpContextAccessorMock.Object);

            var currentUserServiceMock = new Mock<ICurrentUser>();
            currentUserServiceMock.Setup(s => s.GetUserId()).Returns("pesho");


            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile(currentUserServiceMock.Object)); 
            });

            var mapperMock = mapperConfig.CreateMapper();
            var mapperMock2 = new Mock<IMapper>();

            mapperMock2.Setup(mapper => mapper.Map<Resource, ResourceModel>(It.IsAny<Resource>()))
                .Returns(new ResourceModel()
                {
                    UserId = "pesho",
                    Content = "sdadasdas",
                    DateTime = DateTime.UtcNow.ToString()
                });

            CommentService = new CommentService(
                DbContext,
                currentUserServiceMock.Object,
                mapperMock);

            ResourceService = new ResourceService(DbContext,
                mapperMock,
                currentUserServiceMock.Object);

            var globalResource = new Resource()
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
            var resource1 = new Resource()
            {
                UserId = "alice",
                Content = "I really enjoyed reading this article!",
                Id = Guid.NewGuid(),
                IsPublic = true,
                Title = "Amazing Article,comment here!!!,comment here!!!",
                ImageUrl = "https://example.com/image1.jpg",
                CreatedBy = "alice",
                CreatedOn = DateTime.UtcNow.AddDays(-5),
                UpdatedBy = "alice",
                UpdatedOn = DateTime.UtcNow.AddDays(-2),
            };
            var resource2 = new Resource()
            {
                UserId = "bob",
                Content = "Great work! Keep it up!",
                Id = Guid.NewGuid(),
                IsPublic = false,
                Title = "My Project Update,comment here!!!",
                ImageUrl = "https://example.com/image2.jpg",
                CreatedBy = "bob",
                CreatedOn = DateTime.UtcNow.AddDays(-10),
                UpdatedBy = "bob",
                UpdatedOn = DateTime.UtcNow.AddDays(-7),
            };
            var resource3 = new Resource()
            {
                UserId = "charlie",
                Content = "This is an interesting topic.",
                Id = Guid.NewGuid(),
                IsPublic = true,
                Title = "Discussion Thread, comment here!!!",
                ImageUrl = "https://example.com/image3.jpg",
                CreatedBy = "charlie",
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedBy = "charlie",
                UpdatedOn = DateTime.UtcNow,
            };

            var comment1 = new Comment()
            {
                UserId = "pesho123",
                Content = "This is a very nice way to create a comment",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "pesho",
                UpdatedOn = DateTime.Now,
                UpdatedBy = "pesho"
            };

            var comment2 = new Comment()
            {
                UserId = "alice567",
                Content = "I totally agree with your comment!",
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                CreatedBy = "alice",
                UpdatedOn = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = "alice"
            };

            var comment3 = new Comment()
            {
                UserId = "bob321",
                Content = "Nice work! Keep it up!",
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                CreatedBy = "bob",
                UpdatedOn = DateTime.UtcNow.AddDays(-1),
                UpdatedBy = "bob"
            };

            var comment4 = new Comment()
            {
                UserId = "charlie456",
                Content = "Thanks for sharing this information.",
                CreatedOn = DateTime.UtcNow.AddDays(-3),
                CreatedBy = "charlie",
                UpdatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedBy = "charlie"
            };

            var resourceLike1 = new ResourceLike()
            {
                UserId = "pesho",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                ResourceId = resource1.Id,
            };

            var resourceLike2 = new ResourceLike()
            {
                UserId = "alice",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ResourceId = resource1.Id,
            };

            var resourceLike3 = new ResourceLike()
            {
                UserId = "bob",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                ResourceId = resource2.Id,
            };

            var resourceLike4 = new ResourceLike()
            {
                UserId = "charlie",
                CreatedAt = DateTime.UtcNow,
                ResourceId = resource3.Id,
            };

            var category1 = new Category()
            {
                Id = 1,
                Name = "C#"
            };

            var category2 = new Category()
            {
                Id = 2,
                Name = "JavaScript"
            };

            var category3 = new Category()
            {
                Id = 3,
                Name = "Python"
            };

            var category4 = new Category()
            {
                Id = 4,
                Name = "Java"
            };

            var category5 = new Category()
            {
                Id = 5,
                Name = "PHP"
            };

            resources.Add(globalResource);
            resources.Add(resource1);
            resources.Add(resource2);
            resources.Add(resource3);

            comments.Add(comment1);
            comments.Add(comment2);
            comments.Add(comment3);
            comments.Add(comment4);

            resourceLikes.Add(resourceLike1);
            resourceLikes.Add(resourceLike2);
            resourceLikes.Add(resourceLike3);
            resourceLikes.Add(resourceLike4);

            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);
            categories.Add(category4);
            categories.Add(category5);

            DbContext.AddRangeAsync(resources);
            DbContext.AddRangeAsync(comments);
            DbContext.AddRangeAsync(resourceLikes);
            DbContext.AddRangeAsync(categories);

            DbContext.SaveChanges();
        }


        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
