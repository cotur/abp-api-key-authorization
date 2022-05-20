using Volo.Abp.Reflection;

namespace Cotur.Abp.ApiKeyAuthorization.Permissions;

public class ApiKeyAuthorizationPermissions
{
    public const string GroupName = "ApiKeyAuthorization";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ApiKeyAuthorizationPermissions));
    }
}
