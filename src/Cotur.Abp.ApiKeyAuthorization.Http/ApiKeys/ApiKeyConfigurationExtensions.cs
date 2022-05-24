using Microsoft.AspNetCore.Builder;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public static class ApiKeyConfigurationExtensions
{
    public static void UseApiKeyAuthorization(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
        {
            appBuilder.UseMiddleware<ApiKeyAuthorizationMiddleware>();
        });
    }
}