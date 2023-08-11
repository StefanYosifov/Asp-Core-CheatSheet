namespace _Project_CheatSheet.Features.Topics.Services
{
    using _Project_CheatSheet.Infrastructure.Data.SQL;
    using Amazon.S3;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TopicService : ITopicService
    {
        private readonly CheatSheetDbContext context;
        private readonly IMapper mapper;
        private readonly IAmazonS3 amazonS3;

        public TopicService(
            CheatSheetDbContext context,
            IMapper mapper,
            IAmazonS3 amazonS3)
        {
            this.context = context;
            this.mapper = mapper;
            this.amazonS3 = amazonS3;
        }

        public async Task<TopicRespondModel> GetTopic(string id)
        {
            var topic = await context.Topics
                .Include(t => t.Video)
                .FirstOrDefaultAsync(t => t.Id.ToString() == id);

            return mapper.Map<TopicRespondModel>(topic);
        }

        public async Task<TopicDetailRespondModel> GetTopicDetail(string id)
        {
            return (await
                context.Topics
                    .ProjectTo<TopicDetailRespondModel>(mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.Id.ToString() == id))!;
        }

        public async Task<IEnumerable<TopicRespondModel>> GetAllTopics(string id)
        {
            return await context.Topics
                .Where(t => t.CourseId.ToString() == id.ToLower())
                .ProjectTo<TopicRespondModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}