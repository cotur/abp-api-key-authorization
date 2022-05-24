using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Cotur.Abp.ApiKeyAuthorization.Permissions;

public class ApiKeyAuthorizationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var apiKeyGroup = context.AddGroup(ApiKeyAuthorizationPermissions.GroupName, L("Permission:ApiKeys:ApiKeyManagement"));

        var apiKeyPermissions = apiKeyGroup.AddPermission(ApiKeyAuthorizationPermissions.ApiKeys.Default, L("Permission:ApiKeys:ApiKeyManagement"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Create, L("Permission:ApiKeys:Create"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Update, L("Permission:ApiKeys:Edit"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.Delete, L("Permission:ApiKeys:Delete"));
        apiKeyPermissions.AddChild(ApiKeyAuthorizationPermissions.ApiKeys.ManagePermissions, L("Permission:ApiKeys:ManagePermissions"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApiKeyAuthorizationResource>(name);
    }
}
