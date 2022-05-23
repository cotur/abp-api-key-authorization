using Volo.Abp;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class ApiKeyResolveContext : IApiKeyResolveContext
{
    public IServiceProvider ServiceProvider { get; }
    public string ApiKeyValue { get; set; }
    public string ApiKeyName { get; }
    
    public virtual bool HasResolvedApiKey()
    {
        return !string.IsNullOrWhiteSpace(ApiKeyValue);
    }

    public ApiKeyResolveContext(IServiceProvider serviceProvider, string apiKeyName)
    {
        ServiceProvider = serviceProvider;
        ApiKeyName = Check.NotNullOrWhiteSpace(apiKeyName, nameof(apiKeyName));
    }
}