using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public interface IApiKeysAppService : ICrudAppService<ApiKeyDto, Guid, PagedAndSortedResultRequestDto, ApiKeyCreateDto, ApiKeyUpdateDto>
{
    
}