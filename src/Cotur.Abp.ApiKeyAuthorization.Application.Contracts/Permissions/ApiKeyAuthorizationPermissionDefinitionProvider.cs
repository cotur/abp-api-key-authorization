using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Cotur.Abp.ApiKeyAuthorization.Permissions;

public class ApiKeyAuthorizationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var apiKeyGroup = context.AddGroup(ApiKeyAuthorizationPermissions.GroupName, L("Permission:ApiKeyAuthorization"));
        
        var apiKeyPermissions = apiKeyGroup.AddPermission(ApiKeyAuthorizationPermissions.ApiKeys.Default, L("ApiKeys:ApiKeyManagement"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Create, L("ApiKeys:Create"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Update, L("ApiKeys:Edit"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Delete, L("ApiKeys:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApiKeyAuthorizationResource>(name);
    }
}
