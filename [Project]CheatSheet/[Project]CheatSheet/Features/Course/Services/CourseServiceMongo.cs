namespace _Project_CheatSheet.Features.Course.Services
{
    using _Project_CheatSheet.Features.Course.Interfaces;
    using _Project_CheatSheet.Features.Course.Models;
    using _Project_CheatSheet.Infrastructure.MongoDb.Models;
    using _Project_CheatSheet.Infrastructure.MongoDb.Services;
    using AutoMapper;

    public class CourseServiceMongo : ICourseServiceMongo
    {
        private readonly ICourseDetailsService context;
        private readonly IMapper mapper;

        public CourseServiceMongo(
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
