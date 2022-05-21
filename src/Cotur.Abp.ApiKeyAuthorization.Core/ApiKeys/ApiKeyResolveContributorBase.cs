namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public abstract class ApiKeyResolveContributorBase : IApiKeyResolveContributor
{
    public abstract string Name { get; }
    public abstract Task ResolveAsync(IApiKeyResolveContext context);
}