using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyPrincipleProvider : IApiKeyPrincipleProvider, ITransientDependency
{
    private readonly IEnumerable<IApiKeyStorage> _apiKeyStorages;

    public ApiKeyPrincipleProvider(IEnumerable<IApiKeyStorage> apiKeyStorages)
    {
        _apiKeyStorages = apiKeyStorages;
    }

    public async Task<ClaimsPrincipal?> GetApiKeyPrincipleOrNullAsync(string key)
    {
        ApiKeyInfo? apiKeyInfo = null;

        foreach (var apiKeyStorage in _apiKeyStorages)
        {
            apiKeyInfo = await apiKeyStorage.FindAsync(key);

            if (apiKeyInfo != null)
            {
                break;
            }
        }
        
        if (apiKeyInfo == null || apiKeyInfo.Active == false)
        {
            return null;
        }

        return GetApiKeyPrinciple(apiKeyInfo);
    }

    private ClaimsPrincipal GetApiKeyPrinciple(ApiKeyInfo? apiKeyInfo)
    {
        var claims = new List<Claim>
        {
            new Claim(AbpClaimTypes.UserId, apiKeyInfo.Id),
            new Claim(AbpClaimTypes.TenantId, apiKeyInfo.TenantId)
        };
        
        return new ClaimsPrincipal(new ClaimsIdentity(claims, ApiKeyAuthorizationConsts.API_KEY_AUTHORIZATION_METHOD));
    }
}