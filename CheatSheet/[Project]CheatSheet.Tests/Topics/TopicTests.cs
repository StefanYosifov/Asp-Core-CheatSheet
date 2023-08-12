namespace _Project_CheatSheet.Tests.Topics
{
    using Fixtures;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    [Collection("Our Test Collection #6")]

    public class TopicTests : IClassFixture<CoursesTestFixture>
    {

        private readonly CoursesTestFixture fixture;

        public TopicTests(CoursesTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetTopicReturnsAValidObjectWhenGivenValidId()
        {
            var findTopic = await fixture.DbContext.Topics.FirstOrDefaultAsync();

            var result = await fixture.TopicService.GetTopic(findTopic.Id.ToString());

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTopicShouldNReturnEmptyCollectionIfIncorrectIdHasBeenPassed()
        {
            var randomId=Guid.NewGuid().ToString();

            var result = await fixture.TopicService.GetAllTopics(randomId);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllTopicsShouldNotReturn0IfValidDataHasBeenPassed()
        {
            var course = await fixture.DbContext.Courses.Where(c => c.Topics.Count > 0).FirstOrDefaultAsync();

            var result = await fixture.TopicService.GetAllTopics(course.Id.ToString());

            Assert.NotEmpty(result);
        }
       


    }
}
