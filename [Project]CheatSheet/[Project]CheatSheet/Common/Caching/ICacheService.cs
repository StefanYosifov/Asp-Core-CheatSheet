namespace _Project_CheatSheet.Common.Caching
{
    public interface ICacheService
    {
        public void SetCache<T>(string cacheKey, T result, double expireAfterMinutes);
    }
}