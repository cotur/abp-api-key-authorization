using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public interface IApiKeyResolveContext : IServiceProviderAccessor
{
    [CanBeNull]
    string ApiKeyValue { get; set; }
    
    [NotNull]
    public string ApiKeyName { get; }
}