namespace _Project_CheatSheet.Features.Course
{
    using _Project_CheatSheet.Infrastructure.MongoDb.Models;
    using Common.Filters;

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
        [ActionFilter("", CourseMessages.OnUnsuccessfulCourseRetrieval, StatusCodes.Status404NotFound)]
        public async Task<CourseRespondModel> GetCourse(string id)
            => await service.GetCourseDetails(id);

        [HttpGet("payment/{id}")]
        [ActionFilter("", CourseMessages.OnUnsuccessfulCourseRetrieval)]
        public async Task<CourseRespondPaymentModel> GetCoursePaymentDetails(string id)
            => await service.GetPaymentDetails(id.ToLower());

        [HttpGet("all/{page}")]
        [ActionFilter()]
        public async Task<CourseRespondAllPaginated> GetAllCourses([FromRoute]int page, [FromQuery] CourseRequestQueryModel query)
            => await service.GetAllCourses(page, query);

        [HttpGet("my/{page}")]
        [ActionFilter()]
        public async Task<IEnumerable<CourseRespondAllModel>> GetMyCourses(int page, [FromQuery] string? toggle)
            => await service.GetMyCourses(page, toggle);

        [HttpGet("languages")]
        [ActionFilter()]
        public async Task<CourseFilterModel> GetCoursesFilteringData()
            => await service.GetCoursesFilteringData();

        [HttpPost("payment/{id}")]
        [ActionFilter(CourseMessages.OnSuccessfulPayment, CourseMessages.OnSuccessfulPayment, StatusCodes.Status403Forbidden)]
        public async Task<bool> JoinCourse(string id)
            => await service.JoinCourse(id);

        [HttpGet("upcomingFeatured")]
        public async Task<ICollection<CourseRespondUpcomingModel>> GetUpcomingCourses()
            => await service.GetUpcomingCourses();

        [HttpGet("preview/{id}")]
        public async Task<CoursePreviewModel> GetCoursePreviewDetails(string id)
            => await service.GetPreviewCourseData(id);

        [HttpGet("preview/extra/{id}")]
        public async Task<CourseDetails> GetCourseExtraDetails(string id)
            => await mongoService.GetDetails(id);
    }
}