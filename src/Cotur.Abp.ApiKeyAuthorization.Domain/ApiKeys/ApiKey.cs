using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKey : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }
    public string Name { get; protected set; }
    public string Key { get; protected set; }
    public bool Active { get; protected set; }
    
    public DateTime? ExpireAt { get; protected set; }
    
    protected ApiKey()
    {
        
    }

    public ApiKey(Guid id, string key, string value, bool active, DateTime? expireAt = null, Guid? tenantId = null): base(id)
    {
        TenantId = tenantId;
        SetName(key);
        SetKey(value);
        Active = active;
        ExpireAt = expireAt;
    }

    protected virtual void SetKey(string value)
    {
        Key = Check.NotNullOrWhiteSpace(value, nameof(value), ApiKeyConsts.MaxKeyLength);
    }

    protected virtual void SetName(string key)
    {
        Name = Check.NotNullOrWhiteSpace(key, nameof(key), ApiKeyConsts.MaxNameLength);
    }
}