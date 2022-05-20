using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Cotur.Abp.ApiKeyAuthorization.Permissions;

public class ApiKeyAuthorizationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ApiKeyAuthorizationPermissions.GroupName, L("Permission:ApiKeyAuthorization"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApiKeyAuthorizationResource>(name);
    }
}
