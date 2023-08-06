namespace _Project_CheatSheet.Area.AdminServices
{
    using Common.Filters;

    using Features;

    using Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    [Authorize(Policy = "ElevatedRights")]
    [Route("/admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpGet("resources")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<ICollection<ResourceAdminModel>> GetResources([FromQuery] ResourceAdminQueryModel query)
        {
            return await service.GetListOfCourses(query);
        }

        [HttpGet("resource/{courseId}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<ICollection<CoursePrimaryDetailsAdminModel>> GetCoursePrimaryDetails(string courseId) 
            => await service.GetCourseTopicAndVideo(courseId);

        [HttpGet("resource/secondary/{topicId}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<CourseSecondaryDetailsEditAdminModel> GetCourseSecondaryDetails(string topicId) 
            => await service.GetCourseSecondaryDetails(topicId);

        [HttpPatch("resource/secondary/edit/{topicId}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> EditTopicDetails(string topicId, CourseSecondaryDetailsEditAdminModel editTopicModel) 
            => await service.UpdateCourseSecondaryDetails(topicId, editTopicModel);

        [HttpPost("course/create")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> CreatedCourse([FromBody]CreateCourseAdminModel createdCourse) 
            => await service.CreateCourse(createdCourse);

        [HttpPost("topic/create/{courseName}")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<string> CreateTopicToAdd(string courseName, [FromBody]TopicCreateDetailsAdminModel createdTopic)
            => await service.AddTopicToCourse(courseName, createdTopic);
    }
}