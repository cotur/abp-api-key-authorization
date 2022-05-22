using System;
using Volo.Abp.Application.Dtos;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyUpdateDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Key { get; set; }
}