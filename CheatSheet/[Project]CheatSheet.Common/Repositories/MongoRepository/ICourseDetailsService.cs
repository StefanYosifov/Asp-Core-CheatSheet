namespace _Project_CheatSheet.Common.Repositories.MongoRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using _Project_CheatSheet.Infrastructure.Data.MongoDb.Models;

    public interface ICourseDetailsService
    {
        Task<ICollection<CourseDetails>> Get();
        Task<CourseDetails> Get(string id);

        Task<CourseDetails> GetByCourseId(string courseId);
        Task<CourseDetails> Create();
        void Update();
        void Delete();
    }
}
