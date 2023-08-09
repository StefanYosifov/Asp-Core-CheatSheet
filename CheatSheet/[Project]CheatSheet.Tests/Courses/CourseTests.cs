namespace _Project_CheatSheet.Tests.Courses
{
    using Features.Course.Models;

    using Fixtures;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    public class CourseTests : IClassFixture<CoursesTestFixture>
    {

        private readonly CoursesTestFixture fixture;

        public CourseTests(CoursesTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetAllCoursesShouldReturnExpectedCount()
        {
            const int expectedResult = 5;
            const int page = 1;
            var query = new CourseRequestQueryModel()
            {
                Search = null,
                Categories = { "1" },
                Sort = 0
            };

            var result = await fixture.CourseService.GetAllCourses(1, query);
            Assert.Equal(expectedResult, result.Courses.Count);
        }

        [Fact]
        public async Task GetAllCoursesShouldReturn0IfInvalidCategoryHasBeenGiven()
        {
            const int expectedResult = 0;
            const int page = 1;
            var query = new CourseRequestQueryModel()
            {
                Search = null,
                Categories = { $"{Guid.NewGuid().ToString()}" },
                Sort = 0
            };

            var result = await fixture.CourseService.GetAllCourses(1, query);
            Assert.NotNull(result);
            Assert.Equal(expectedResult,result.Courses.Count);
        }

        [Fact]
        public async Task JoinCourseShouldReturnTrueIfTheUserSuccessfullyJoinsTheCourse()
        {
            var findCourse =
                await fixture.DbContext.Courses
                    .FirstOrDefaultAsync(c => c.UsersCourses.All(uc => uc.UserId != "pesho"));

            var result = await fixture.CourseService.JoinCourse(findCourse.Id.ToString());

            Assert.True(result);
        }


        
        [Fact]
        public async Task JoinCourseShouldReturnFalseIfTheUserHasAlreadyJoinedTheCourseBefore()
        {
            var findCourse =
                await fixture.DbContext.Courses
                    .FirstOrDefaultAsync(c => c.UsersCourses.All(uc => uc.UserId == "pesho"));

            var result = await fixture.CourseService.JoinCourse(findCourse.Id.ToString());

            Assert.True(result);
        }

        [Fact]
        public async Task GetMyCoursesShouldReturnCorrectAmountOfCourses()
        {
            const int expectedCount = 1;
            var findCourse =
                await fixture.DbContext.Courses.FirstOrDefaultAsync(c =>
                    c.UsersCourses.All(uc => uc.UserId != "pesho"));

            await fixture.CourseService.JoinCourse(findCourse.Id.ToString());

            var result = await fixture.CourseService.GetMyCourses(1, "");

        }

    }
}
