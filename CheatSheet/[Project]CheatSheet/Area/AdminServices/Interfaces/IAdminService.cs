namespace _Project_CheatSheet.Area.AdminServices.Interfaces
{
    using Models.Courses;
    using Models.Issues;

    public interface IAdminService
    {

        Task<ICollection<ResourceAdminModel>> GetListOfCourses(ResourceAdminQueryModel query);

        Task<ICollection<CoursePrimaryDetailsAdminModel>> GetCourseTopicAndVideo(string courseId);

        Task<CourseSecondaryDetailsEditAdminModel> GetCourseSecondaryDetails(string courseId);

        Task<string> UpdateCourseSecondaryDetails(string topicId,CourseSecondaryDetailsEditAdminModel updatedTopic);

        Task<string> CreateCourse(CreateCourseAdminModel createdCourse);

        Task<string> AddTopicToCourse(string courseName, TopicCreateDetailsAdminModel createdTopic);

        Task<PaginatedIssuesAdminModel> GetIssues(IssueQueryModel query);

        Task<IssueFilteringAdminModel> GetFilteringData();

        Task<string> ResolveIssue(int issueId);
    }
}
