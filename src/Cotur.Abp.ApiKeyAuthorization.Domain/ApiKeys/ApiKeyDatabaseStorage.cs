using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDatabaseStorage : IApiKeyStorage, ITransientDependency
{
    private readonly IDistributedCache<ApiKey, Guid> _distributedCache;
    private readonly IRepository<ApiKey, Guid> _apiKeyRepository;

    public ApiKeyDatabaseStorage(IDistributedCache<ApiKey, Guid> distributedCache, IRepository<ApiKey, Guid> apiKeyRepository)
    {
        _distributedCache = distributedCache;
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task<ApiKey> GetOrNullAsync(Guid id)
    {
        var apiKey = await _apiKeyRepository.FindAsync(id);

        return apiKey;
    }
}