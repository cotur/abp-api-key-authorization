namespace Cotur.Abp.ApiKeyAuthorization;

public static class ApiKeyAuthorizationDbProperties
{
    public static string DbTablePrefix { get; set; } = "ApiKeyAuthorization";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ApiKeyAuthorization";
}
