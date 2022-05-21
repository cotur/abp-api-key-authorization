using Volo.Abp.Reflection;

namespace Cotur.Abp.ApiKeyAuthorization.Permissions;

public class ApiKeyAuthorizationPermissions
{
    public const string GroupName = "ApiKeyAuthorization";

    public static class ApiKeys
    {
        public const string Default = GroupName + ".Tenants";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ApiKeyAuthorizationPermissions));
    }
}
