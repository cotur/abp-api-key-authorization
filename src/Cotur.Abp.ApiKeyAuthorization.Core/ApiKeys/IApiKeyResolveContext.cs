using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyResolveContext : IServiceProviderAccessor
{
    [CanBeNull]
    string ApiKeyValue { get; set; }
}