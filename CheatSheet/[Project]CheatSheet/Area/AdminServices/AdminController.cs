namespace _Project_CheatSheet.Area.AdminServices
{
    using _Project_CheatSheet.Area.AdminServices.Models.Courses;
    using Common.Filters;
    using Common.Pagination;

    using Features;

    using Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models;
    using Models.Issues;

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

        [HttpGet("issues")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<PaginatedIssuesAdminModel> GetAllIssues([FromQuery]IssueQueryModel query)
            => await service.GetIssues(query);

        [HttpGet("issues/filters")]
        [ActionHandlingFilter]
        [ExceptionHandlingActionFilter]
        public async Task<IssueFilteringAdminModel> GetFilteringData()
            => await service.GetFilteringData();

        [HttpDelete("issues/delete/{issueId}")]
        public async Task<string> ResolveIssue(int issueId)
            => await service.ResolveIssue(issueId);
    }
}