namespace _Project_CheatSheet.Features.Course.Interfaces
{
    using _Project_CheatSheet.Features.Course.Models;
    using _Project_CheatSheet.Infrastructure.MongoDb.Models;

    public interface ICourseMongoService
    {
        Task<CourseDetails> GetDetails(string id);
    }
}
