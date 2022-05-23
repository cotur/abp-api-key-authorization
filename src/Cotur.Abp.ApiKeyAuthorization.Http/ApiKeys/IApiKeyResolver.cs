namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public interface IApiKeyResolver
{
    Task<ApiKeyResolveResult> ResolveApiKeyAsync();
}