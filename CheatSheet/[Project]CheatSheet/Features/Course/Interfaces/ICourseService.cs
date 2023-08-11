namespace _Project_CheatSheet.Features.Course.Interfaces
{
    using Models;

    public interface ICourseService
    {

        public Task<bool> JoinCourse(string id);
        public Task<CourseAllPaginatedModel> GetAllCourses(int page, CourseRequestQueryModel query);
        public Task<IEnumerable<CourseAllModel>> GetMyCourses(int page, string? toggle);
        public Task<CourseModel> GetCourseDetails(string id);
        public Task<CoursePaymentModel> GetPaymentDetails(string id);
        public Task<CourseFilterModel> GetCoursesFilteringData();
        public Task<ICollection<CourseUpcomingModel>> GetUpcomingCourses();
        public Task<CoursePreviewModel> GetPreviewCourseData(string id);
    }
}