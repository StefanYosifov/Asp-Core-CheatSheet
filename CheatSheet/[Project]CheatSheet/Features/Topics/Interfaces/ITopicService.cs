namespace _Project_CheatSheet.Features.Topics.Interfaces
{
    using Models;

    public interface ITopicService
    {
        public Task<TopicRespondModel?> GetTopic(string id);

        public Task<TopicDetailRespondModel> GetTopicDetail(string id);

        public Task<IEnumerable<TopicRespondModel>> GetAllTopics(string id);
    }
}