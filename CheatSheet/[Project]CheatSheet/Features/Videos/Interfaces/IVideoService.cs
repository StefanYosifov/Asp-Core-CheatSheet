namespace _Project_CheatSheet.Features.Videos.Interfaces
{
    public interface IVideoService
    {
        public Task<string?> GetVideoId(Guid topicId);
    }
}