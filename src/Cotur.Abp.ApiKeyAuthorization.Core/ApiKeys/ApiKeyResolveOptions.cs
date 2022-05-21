namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyResolveOptions
{
    public List<IApiKeyResolveContributor> ApiKeyResolvers { get; }

    public ApiKeyResolveOptions()
    {
        ApiKeyResolvers = new List<IApiKeyResolveContributor>();
    }
}