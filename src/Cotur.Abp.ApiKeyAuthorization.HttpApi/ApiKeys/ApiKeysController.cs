using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

[Authorize(ApiKeyAuthorizationPermissions.ApiKeys.Default)]
[Area(ApiKeyAuthorizationRemoteServiceConsts.ModuleName)]
[ControllerName("ApiKeys")]
[Route("api/identity/api-keys")]
public class ApiKeysController : ApiKeyAuthorizationController, IApiKeysAppService
{
    private readonly IApiKeysAppService _apiKeysAppService;

    public ApiKeysController(IApiKeysAppService apiKeysAppService)
    {
        _apiKeysAppService = apiKeysAppService;
    }

    [HttpGet]
    [Route("{id}")]
    public Task<ApiKeyDto> GetAsync(Guid id)
    {
        return _apiKeysAppService.GetAsync(id);
    }

    [HttpGet]
    public Task<PagedResultDto<ApiKeyDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return _apiKeysAppService.GetListAsync(input);
    }

    [HttpPost]
    public Task<ApiKeyDto> CreateAsync(ApiKeyCreateDto input)
    {
        return _apiKeysAppService.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
    public Task<ApiKeyDto> UpdateAsync(Guid id, ApiKeyUpdateDto input)
    {
        return _apiKeysAppService.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _apiKeysAppService.DeleteAsync(id);
    }
}