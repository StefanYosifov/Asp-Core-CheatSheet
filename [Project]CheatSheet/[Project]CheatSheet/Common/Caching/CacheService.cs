namespace _Project_CheatSheet.Common.Caching
{
    using Microsoft.Extensions.Caching.Memory;

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void SetCache<T>(string cacheKey, T result, double expireAfterMinutes)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireAfterMinutes),
                Priority = CacheItemPriority.Low
            };

            cache.Set(cacheKey, result, cacheEntryOptions);
        }
    }
}