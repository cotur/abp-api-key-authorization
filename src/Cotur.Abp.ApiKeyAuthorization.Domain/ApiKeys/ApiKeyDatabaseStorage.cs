using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Timing;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDatabaseStorage : IApiKeyStorage, ITransientDependency
{
    // TODO : implement caching
    private readonly IObjectMapper _objectMapper;
    private readonly IApiKeyRepository _apiKeyRepository;
    private readonly IClock _clock;

    public ApiKeyDatabaseStorage(
        IObjectMapper objectMapper,
        IApiKeyRepository apiKeyRepository,
        IClock clock)
    {
        _objectMapper = objectMapper;
        _apiKeyRepository = apiKeyRepository;
        _clock = clock;
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
        var apiKey = await _apiKeyRepository.FindByKeyAsync(key, isActive: true, expireAtCanBeNull: true, expireAtStart: _clock.Now);
        
        if (apiKey == null)
        {
            return null;
        }

        return _objectMapper.Map<ApiKey, ApiKeyInfo>(apiKey);
    }
}