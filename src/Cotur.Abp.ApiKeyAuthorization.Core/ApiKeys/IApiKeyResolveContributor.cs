namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyResolveContributor
{
    string Name { get; }
    
    Task ResolveAsync(IApiKeyResolveContext context);
}