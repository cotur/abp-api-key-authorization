using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyPrincipleProvider : IApiKeyPrincipleProvider, ITransientDependency
{
    private readonly IApiKeyStorage _apiKeyStorage;

    public ApiKeyPrincipleProvider(IApiKeyStorage apiKeyStorage)
    {
        _apiKeyStorage = apiKeyStorage;
    }

    public virtual async Task<ClaimsPrincipal?> GetApiKeyPrincipleOrNullAsync(string key)
    {
       var apiKeyInfo = await _apiKeyStorage.FindAsync(key);
        
        if (apiKeyInfo == null || apiKeyInfo.Active == false)
        {
            return null;
        }

        return GetApiKeyPrinciple(apiKeyInfo);
    }

    protected virtual ClaimsPrincipal GetApiKeyPrinciple(ApiKeyInfo apiKeyInfo)
    {
        var claims = new List<Claim>
        {
            new(AbpClaimTypes.UserId, apiKeyInfo.Id),
            new(AbpClaimTypes.TenantId, apiKeyInfo.TenantId)
        };
        
        return new ClaimsPrincipal(new ClaimsIdentity(claims, ApiKeyAuthorizationConsts.API_KEY_AUTHORIZATION_METHOD));
    }
}