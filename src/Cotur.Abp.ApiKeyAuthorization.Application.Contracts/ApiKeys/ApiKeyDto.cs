using System;
using Volo.Abp.Application.Dtos;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Key { get; set; }
    public bool Active { get; set; }
    public DateTime? ExpireAt { get; set; }
}