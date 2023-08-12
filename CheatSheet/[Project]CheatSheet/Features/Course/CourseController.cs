namespace _Project_CheatSheet.Features.Course
{
    using _Project_CheatSheet.Infrastructure.Data.MongoDb.Models;

    using Common.Filters_and_Attributes.Filters;

    using Constants.GlobalConstants.Course;

    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/course")]
    public class CourseController : ApiController
    {
        private readonly ICourseService service;
        private readonly ICourseMongoService mongoService;

        public CourseController(ICourseService service, 
            ICourseMongoService mongoService)
        {
            this.service = service;
            this.mongoService = mongoService;
        }

        [HttpGet("{id}")]
        [ActionHandlingFilter("", CourseMessages.UnsuccessfulCourseRetrieval, StatusCodes.Status404NotFound)]
        public async Task<CourseModel> GetCourse(string id)
            => await service.GetCourseDetails(id);

        [HttpGet("payment/{id}")]
        [ActionHandlingFilter("", CourseMessages.UnsuccessfulCourseRetrieval)]
        public async Task<CoursePaymentModel> GetCoursePaymentDetails(string id)
            => await service.GetPaymentDetails(id.ToLower());

        [HttpGet("all/{page}")]
        [ActionHandlingFilter]
        public async Task<CourseAllPaginatedModel> GetAllCourses([FromRoute]int page, [FromQuery] CourseRequestQueryModel query)
            => await service.GetAllCourses(page, query);

        [HttpGet("my/{page}")]
        [ActionHandlingFilter]
        public async Task<IEnumerable<CourseAllModel>> GetMyCourses(int page, [FromQuery] string? toggle)
            => await service.GetMyCourses(page, toggle);

        [HttpGet("languages")]
        [ActionHandlingFilter]
        public async Task<CourseFilterModel> GetCoursesFilteringData()
            => await service.GetCoursesFilteringData();

        [HttpPost("payment/{id}")]
        [ActionHandlingFilter(CourseMessages.SuccessfulPayment, "", StatusCodes.Status403Forbidden)]
        [ExceptionHandlingActionFilter]
        public async Task<bool> JoinCourse(string id)
            => await service.JoinCourse(id);

        [HttpGet("upcomingFeatured")]
        [ActionHandlingFilter]
        public async Task<ICollection<CourseUpcomingModel>> GetUpcomingCourses()
            => await service.GetUpcomingCourses();

        [HttpGet("preview/{id}")]
        [ActionHandlingFilter]
        public async Task<CoursePreviewModel> GetCoursePreviewDetails(string id)
            => await service.GetPreviewCourseData(id);

        [HttpGet("preview/extra/{id}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<CourseDetails> GetCourseExtraDetails(string id)
            => await mongoService.GetDetails(id);
    }
}