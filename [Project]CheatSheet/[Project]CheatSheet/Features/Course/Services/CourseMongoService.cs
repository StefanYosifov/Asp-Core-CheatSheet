namespace _Project_CheatSheet.Features.Course.Services
{
    using Interfaces;
    using _Project_CheatSheet.Infrastructure.MongoDb.Models;
    using _Project_CheatSheet.Infrastructure.MongoDb.Services;
    using AutoMapper;

    public class CourseMongoService : ICourseMongoService
    {
        private readonly ICourseDetailsService context;
        private readonly IMapper mapper;

        public CourseMongoService(
            ICourseDetailsService context, 
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CourseDetails> GetDetails(string id)
        {
            return mapper.Map<CourseDetails>(await context.GetByCourseId(id));
        }
    }
}
