using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDatabaseStorage : IApiKeyStorage, ITransientDependency
{
    // TODO : implement caching
    private readonly IApiKeyRepository _apiKeyRepository;

    public ApiKeyDatabaseStorage(IApiKeyRepository apiKeyRepository)
    {
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<ApiKeyInfo> FindAsync(Guid id)
    {
        var apiKey = await _apiKeyRepository.FindAsync(id);

        if (apiKey == null)
        {
            return null;
        }

        return CreateApiKeyInfo(apiKey);
    }

    public async Task<ApiKeyInfo> FindAsync(string key)
    {
        var apiKey = await _apiKeyRepository.FindByKeyAsync(key);
        
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