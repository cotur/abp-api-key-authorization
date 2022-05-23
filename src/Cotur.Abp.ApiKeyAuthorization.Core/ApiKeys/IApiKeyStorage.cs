using JetBrains.Annotations;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyStorage
{
    Task<ApiKeyInfo?> FindAsync(Guid id);
    
    Task<ApiKeyInfo?> FindAsync([NotNull] string key);
}