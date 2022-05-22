using JetBrains.Annotations;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyStorage
{
    Task<ApiKeyInfo?> GetOrNullAsync(Guid id);
    
    Task<ApiKeyInfo?> GetOrNullAsync([NotNull] string key);
}