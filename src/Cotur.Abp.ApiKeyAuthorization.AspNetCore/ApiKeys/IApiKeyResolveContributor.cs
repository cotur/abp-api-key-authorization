namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public interface IApiKeyResolveContributor
{
    string Name { get; }
    
    Task ResolveAsync(IApiKeyResolveContext context);
}