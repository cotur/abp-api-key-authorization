using System;
using Cotur.Abp.ApiKeyAuthorization.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
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
    public ApiKeysAppService(IRepository<ApiKey, Guid> repository) : base(repository)
    {
        GetListPolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Default;
        GetPolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Default;
        CreatePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Create;
        UpdatePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Update;
        DeletePolicyName = ApiKeyAuthorizationPermissions.ApiKeys.Delete;
    }
}