namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class ApiKeyResolveOptions
{
    public List<IApiKeyResolveContributor> ApiKeyResolvers { get; }

    public ApiKeyResolveOptions()
    {
        ApiKeyResolvers = new List<IApiKeyResolveContributor>();
    }
}