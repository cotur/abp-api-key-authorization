using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Security.Claims;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyPermissionValueProvider : PermissionValueProvider
{
    public const string ProviderName = "ApiKey";
    public override string Name => ProviderName;
    
    public ApiKeyPermissionValueProvider(IPermissionStore permissionStore) : base(permissionStore)
    {
    }

    public override async Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
    {
        var authMethod = context.Principal.Identity?.AuthenticationType;
        var apiKeyUserId = context.Principal?.FindFirst(AbpClaimTypes.UserId)?.Value;

        if (authMethod != ApiKeyAuthorizationConsts.API_KEY_AUTHORIZATION_METHOD ||
            apiKeyUserId == null)
        {
            return PermissionGrantResult.Undefined;
        }
        
        return await PermissionStore.IsGrantedAsync(context.Permission.Name, Name, apiKeyUserId)
            ? PermissionGrantResult.Granted
            : PermissionGrantResult.Undefined;
    }

    public override async Task<MultiplePermissionGrantResult> CheckAsync(PermissionValuesCheckContext context)
    {
        var permissionNames = context.Permissions.Select(x => x.Name).Distinct().ToArray();
        Check.NotNullOrEmpty(permissionNames, nameof(permissionNames));
        
        var authMethod = context.Principal.Identity?.AuthenticationType;
        var apiKeyUserId = context.Principal?.FindFirst(AbpClaimTypes.UserId)?.Value;

        if (authMethod != ApiKeyAuthorizationConsts.API_KEY_AUTHORIZATION_METHOD ||
            apiKeyUserId == null)
        {
            return new MultiplePermissionGrantResult(permissionNames);
        }
        
        return await PermissionStore.IsGrantedAsync(permissionNames, Name, apiKeyUserId);
    }

}