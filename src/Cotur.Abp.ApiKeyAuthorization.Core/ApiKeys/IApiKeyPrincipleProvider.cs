using System.Security.Claims;
using JetBrains.Annotations;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public interface IApiKeyPrincipleProvider
{
    Task<ClaimsPrincipal?> GetApiKeyPrincipleOrNullAsync([NotNull] string key);
}