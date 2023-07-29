namespace _Project_CheatSheet.Infrastructure.MongoDb.Services
{
    using Models;
    using Store;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CourseDetailsService : ICourseDetailsService
    {
        private readonly IMongoCollection<CourseDetails> context;

        public CourseDetailsService(IMongoDbSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            context = database.GetCollection<CourseDetails>(settings.CoursesCollectionName);

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDetails> Create()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CourseDetails>> Get()
        {
            return await context.Find(c=>true).ToListAsync();
        }

        public async Task<CourseDetails> Get(string id)
        {
            return await context.Find(c=>c.Id==id).FirstOrDefaultAsync();
        }

        public async Task<CourseDetails> GetByCourseId(string courseId)
        {
            return await context.Find(c=>c.CourseId==courseId).FirstOrDefaultAsync();
        }
    }
}
