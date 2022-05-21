using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKey : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; protected set; }
    public string Key { get; protected set; }
    public string Value { get; protected set; }
    
    protected ApiKey()
    {
        
    }

    public ApiKey(Guid id, string key, string value, Guid? tenantId): base(id)
    {
        TenantId = tenantId;
        SetKey(key);
        SetValue(value);
    }

    protected virtual void SetValue(string value)
    {
        Value = Check.NotNullOrWhiteSpace(value, nameof(value), ApiKeyConsts.MaxValueLength);
    }

    protected virtual void SetKey(string key)
    {
        Key = Check.NotNullOrWhiteSpace(key, nameof(key), ApiKeyConsts.MaxKeyLength);
    }
}