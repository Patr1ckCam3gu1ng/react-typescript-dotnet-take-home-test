using Carepatron.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Carepatron.DAL.Repositories;

public class CacheRepository : ICacheRepository
{
    private readonly IMemoryCache _cache;

    public CacheRepository(IMemoryCache cache)
    {
        _cache = cache;
    }

    public object GetCache(string keyValue)
    {
        return _cache.Get(keyValue);
    }

    public async Task<object> CreateAsync(string keyValue, object data, IChangeToken cancellationToken)
    {
        _cache.Remove(keyValue);

        return await _cache.GetOrCreateAsync(keyValue,
            cache =>
            {
                cache.SlidingExpiration = TimeSpan.FromMinutes(120);

                return Task.FromResult(data);
            });
    }

    private async Task RemoveAsync(string keyValue)
    {
        await Task.Run(() => { _cache.Remove(keyValue); });
    }
}