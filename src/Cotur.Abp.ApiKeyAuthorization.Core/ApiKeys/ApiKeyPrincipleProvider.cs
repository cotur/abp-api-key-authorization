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

    public async Task<ClaimsPrincipal?> GetApiKeyPrincipleOrNullAsync(string key)
    {
        var apiKeyInfo = await _apiKeyStorage.GetOrNullAsync(key);

        if (apiKeyInfo == null || apiKeyInfo.Active == false)
        {
            return null;
        }

        return GetApiKeyPrinciple(apiKeyInfo);
    }

    private ClaimsPrincipal GetApiKeyPrinciple(ApiKeyInfo apiKeyInfo)
    {
        var claims = new List<Claim>
        {
            new Claim(AbpClaimTypes.UserId, apiKeyInfo.Id),
            new Claim(AbpClaimTypes.TenantId, apiKeyInfo.TenantId)
        };
        
        return new ClaimsPrincipal(new ClaimsIdentity(claims, ApiKeyConsts.API_KEY_AUTHORIZATION_METHOD));
    }
}