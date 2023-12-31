﻿namespace _Project_CheatSheet.Common.Repositories.MongoRepository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using _Project_CheatSheet.Infrastructure.Data.MongoDb.Models;
    using _Project_CheatSheet.Infrastructure.Data.MongoDb.Store;

    using MongoDB.Driver;

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

        public async Task<bool> Create(CourseDetails createData)
        {
            await context.InsertOneAsync(createData);
            return true;
        }

        public async Task<ICollection<CourseDetails>> Get() 
            => await context.Find(c => true).ToListAsync();

        public async Task<CourseDetails> Get(string id) 
            => await context.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task<CourseDetails> GetByCourseId(string courseId) 
            => await context.Find(c => c.CourseId == courseId).FirstOrDefaultAsync();
    }
}
