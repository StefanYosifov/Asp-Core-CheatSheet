namespace _Project_CheatSheet.Infrastructure.MongoDb.Services
{
    using _Project_CheatSheet.Infrastructure.MongoDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
