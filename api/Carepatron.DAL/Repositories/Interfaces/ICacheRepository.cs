using Microsoft.Extensions.Primitives;

namespace Carepatron.DAL.Repositories.Interfaces;

public interface ICacheRepository
{
    Task<object> CreateAsync(string keyValue, object data, IChangeToken cancellationToken);

    object GetCache(string keyValue);
}