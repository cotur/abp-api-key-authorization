using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Cotur.Abp.ApiKeyAuthorization.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

[Authorize(ApiKeyAuthorizationPermissions.ApiKeys.Default)]
public class ApiKeysAppService : 
    CrudAppService<
        ApiKey,
        ApiKeyDto,
        Guid,
        PagedAndSortedResultRequestDto,
        ApiKeyCreateDto,
        ApiKeyUpdateDto>,
    IApiKeysAppService
{
    private readonly IDistributedCache<ApiKeyInfo, string> _distributedCache;

    public ApiKeysAppService(IRepository<ApiKey, Guid> repository, IDistributedCache<ApiKeyInfo, string> distributedCache) : base(repository)
    {
        _distributedCache = distributedCache;
        GetListPolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Default;
        GetPolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Default;
        CreatePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Create;
        UpdatePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Update;
        DeletePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Delete;
    }

    public override async Task<ApiKeyDto> UpdateAsync(Guid id, ApiKeyUpdateDto input)
    {
        var apiKeyDto = await base.UpdateAsync(id, input);

        // cache invalidation
        await _distributedCache.RemoveAsync(apiKeyDto.Key);

        return apiKeyDto;
    }

    public override async Task DeleteAsync(Guid id)
    {
        var apiKeyInfo = await Repository.FindAsync(id);
        
        // cache invalidation
        await _distributedCache.RemoveAsync(apiKeyInfo.Key);
        
        await base.DeleteAsync(id);
    }
}