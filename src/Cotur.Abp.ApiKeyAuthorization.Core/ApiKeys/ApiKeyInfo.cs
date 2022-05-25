namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyInfo
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Key { get; set; }

    public string TenantId { get; set; }

    public bool Active { get; set; }

    public DateTime? ExpireAt { get; set; }
}