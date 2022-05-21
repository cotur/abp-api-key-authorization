namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyResolver
{
    Task<ApiKeyResolveResult> ResolveApiKeyAsync();
}