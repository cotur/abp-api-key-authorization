using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDatabaseStorage : IApiKeyStorage, ITransientDependency
{
    // TODO: implement it
    private readonly IDistributedCache<ApiKey, Guid> _distributedCache;
    private readonly IRepository<ApiKey, Guid> _apiKeyRepository;

    public ApiKeyDatabaseStorage(IDistributedCache<ApiKey, Guid> distributedCache, IRepository<ApiKey, Guid> apiKeyRepository)
    {
        _distributedCache = distributedCache;
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<ApiKeyInfo> GetOrNullAsync(Guid id)
    {
        var apiKey = await _apiKeyRepository.FindAsync(id);

        if (apiKey == null)
        {
            return null;
        }

        return CreateApiKeyInfo(apiKey);
    }

    public async Task<ApiKeyInfo> GetOrNullAsync(string key)
    {
        var apiKey = await _apiKeyRepository.FindAsync(x => x.Key == key);
        
        if (apiKey == null)
        {
            return null;
        }
        
        return CreateApiKeyInfo(apiKey);
    }

    protected virtual ApiKeyInfo CreateApiKeyInfo(ApiKey apiKey)
    {
        var apiKeyInfo = new ApiKeyInfo
        {
            Id = apiKey.Id.ToString(),
            Name = apiKey.Name,
            Key = apiKey.Key,
            TenantId = apiKey.TenantId?.ToString() ?? string.Empty,
            Active = apiKey.Active
        };

        return apiKeyInfo;
    }
}