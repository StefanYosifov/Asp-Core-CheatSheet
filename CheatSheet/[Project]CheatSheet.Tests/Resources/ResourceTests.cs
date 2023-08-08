namespace _Project_CheatSheet.Tests.Resources
{
    using _Project_CheatSheet.Tests.Fixtures;
    using Common.Exceptions;
    using Constants.GlobalConstants.Resource;

    using Features.Resources.Models;

    using Infrastructure.Data.SQL.Models;

    using Microsoft.EntityFrameworkCore;

    using Xunit;


    public class ResourceTests : IClassFixture<ResourcesTestFixture>
    {
        private readonly ResourcesTestFixture fixture;

        public ResourceTests(
            ResourcesTestFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async Task AddResourcesShouldAddValidResourceModelAndReturnSuccessfulMessage()
        {
            var resourceAddModel = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>() { 1, 2, 3 },
            };

            var result = await fixture.ResourceService.AddResources(resourceAddModel);

            Assert.NotNull(result);
            Assert.Equal(ResourceMessages.OnSuccessfulResourceAdd, result);
        }

        [Fact]
        public async Task AddResourceShouldFailIfTheUserAttemptsToAddNonExistingCategory()
        {
            var resourceAddModel = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>() { 11111 },
            };

            var resourceAddModel2 = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>() { 9 },
            };

            var resourceAddModel3 = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>() { -1 },
            };

            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel));
            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel2));
            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel3));


        }

        [Fact]
        public async Task AddResourceShouldFailIfNoCategoriesHaveBeenSelected()
        {
            var resourceAddModel = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>(),
            };

            var resourceAddModel2 = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>(),
            };

            var resourceAddModel3 = new ResourceAddModel()
            {
                Content = "This is a very lengthy content,is it not??",
                ImageUrl = "https://img.freepik.com/free-photo/red-white-cat-i-white-studio_155003-13189.jpg?w=2000",
                Title = "A nice title to display to the user",
                CategoryIds = new List<int>(),
            };

            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel));
            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel2));
            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.AddResources(resourceAddModel3));


        }

        [Fact]
        public async Task GetMyResourceShouldReturnCorrectCountForTheUser()
        {
            var result = fixture.ResourceService.GetMyResources();

            Assert.Equal(1, result.Result.Count());
        }

        [Fact]
        public async Task GetPublicResourcesShouldReturnAllPublicResources()
        {
            ResourceQueryModel queryModel = new ResourceQueryModel()
            {
                Category = null,
                Search = null,
                Sort = null
            };
            var result = fixture.ResourceService.GetPublicResources(1, queryModel);
            Assert.NotNull(result);
            Assert.Equal(3, result.Result.Resources.Count);

        }

        [Fact]
        public async Task RemoveResourceByIdShouldWorkIfTheUserOwningItTriesToDeleteIt()
        {
            var resource = await fixture.DbContext.Resources.Select(r => new
            {
                r.Id,
                r.UserId
            }).FirstOrDefaultAsync(r => r.UserId == "pesho");

            var result = await fixture.ResourceService.RemoveResource(resource.Id.ToString());

            Assert.Equal(ResourceMessages.OnSuccessfulResourceRemove, result);
        }

        [Fact]
        public async Task RemoveResourceByIdShouldThrowAnExceptionIfAnotherUserTriesToDeleteIt()
        {
            var resource = await fixture.DbContext.Resources.Select(r => new
            {
                r.Id,
                r.UserId
            }).FirstOrDefaultAsync(r => r.UserId != "pesho");

            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.RemoveResource(resource.Id.ToString()));

        }

        [Fact]
        public async Task RemoveResourceByIdShouldThrowAnExceptionIfTheResourceDoesNotExist()
        {
            var resourceId=Guid.NewGuid().ToString();
            await Assert.ThrowsAsync<CustomException>(() => fixture.ResourceService.RemoveResource(resourceId));
        }

        [Fact]
        public async Task RemoveResourceByIdShouldThrowAnExceptionIfTheResourceHasBeenDeleted()
        {
            var resource = new Resource()
            {
                Content = "aaaaaaaaaaaaaaaaaaaaaa",
                CreatedBy = "pesho",
                ImageUrl = "https://imageurl.com",
                IsDeleted = true,
                IsPublic = true,
                Title = "Test title 123, test 123 123",
                UserId = "pesho",
            };

            await fixture.DbContext.Resources.AddAsync(resource);
            await fixture.DbContext.SaveChangesAsync();

            await Assert.ThrowsAsync<ServiceException>(() => fixture.ResourceService.RemoveResource(resource.Id.ToString()));
        }

        [Fact]
        public async Task ChangeVisibilityShouldChangeBooleanIfCorrect()
        {
            var resource = await fixture.DbContext.Resources.Select(r => new
            {
                r.Id,
                r.UserId
            }).FirstOrDefaultAsync(r => r.UserId == "pesho");

            var result = await fixture.ResourceService.ChangeVisibility(resource.Id.ToString());

            Assert.NotNull(result);
            Assert.Equal(ResourceMessages.SuccessfullyVisibilityChanged,result);
        }

        [Fact]
        public async Task ChangeVisibilityShouldNotWorkIfAnotherUserTriesToChangeIt()
        {
            var resource = await fixture.DbContext.Resources.Select(r => new
            {
                r.Id,
                r.UserId
            }).FirstOrDefaultAsync(r => r.UserId != "pesho");

           await Assert.ThrowsAsync<ServiceException>(()=> fixture.ResourceService.ChangeVisibility(resource.Id.ToString()));
        }

        [Fact]
        public async Task ChangeVisibilityShouldNotWorkIfTheResourceHasBeenDeleted()
        {
            var resource = new Resource()
            {
                Content = "aaaaaaaaaaaaaaaaaaaaaa",
                CreatedBy = "pesho",
                ImageUrl = "https://imageurl.com",
                IsDeleted = true,
                IsPublic = true,
                Title = "Test title 123, test 123 123",
                UserId = "pesho",
            };

            await fixture.DbContext.Resources.AddAsync(resource);
            await fixture.DbContext.SaveChangesAsync();

            await Assert.ThrowsAsync<ServiceException>(()=> fixture.ResourceService.ChangeVisibility(resource.Id.ToString()));

        }


    }
}
