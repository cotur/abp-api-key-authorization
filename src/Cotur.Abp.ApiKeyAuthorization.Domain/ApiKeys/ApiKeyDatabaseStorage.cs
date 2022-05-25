using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Timing;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDatabaseStorage : IApiKeyStorage, ITransientDependency
{
    private readonly IObjectMapper _objectMapper;
    private readonly IApiKeyRepository _apiKeyRepository;
    private readonly IClock _clock;
    private readonly IDistributedCache<ApiKeyInfo, string> _distributedCache;

    public ApiKeyDatabaseStorage(
        IObjectMapper objectMapper,
        IApiKeyRepository apiKeyRepository,
        IClock clock,
        IDistributedCache<ApiKeyInfo, string> distributedCache)
    {
        _objectMapper = objectMapper;
        _apiKeyRepository = apiKeyRepository;
        _clock = clock;
        _distributedCache = distributedCache;
    }

    public virtual async Task<ApiKeyInfo> FindAsync(Guid id)
    {
        var apiKey = await _apiKeyRepository.FindAsync(id);

        if (apiKey == null)
        {
            return null;
        }

        return _objectMapper.Map<ApiKey, ApiKeyInfo>(apiKey);
    }

    public virtual async Task<ApiKeyInfo> FindAsync(string key)
    {
        var apiKeyInfo = await _distributedCache.GetOrAddAsync(
            key, //Cache key
            async () => await FindApiKeyFromDatabaseAsync(key),
            () => new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            }
        );

        if (apiKeyInfo.ExpireAt < _clock.Now)
        {
            return null;
        }

        return apiKeyInfo;
    }

    public virtual async Task<ApiKeyInfo> FindApiKeyFromDatabaseAsync(string key)
    {
        var apiKey = await _apiKeyRepository.FindByKeyAsync(key, isActive: true, expireAtCanBeNull: true, expireAtStart: _clock.Now);
        
        if (apiKey == null)
        {
            return null;
        }

        return _objectMapper.Map<ApiKey, ApiKeyInfo>(apiKey);
    }
}