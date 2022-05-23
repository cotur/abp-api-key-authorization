using System;
using Microsoft.AspNetCore.Builder;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public static class ApiKeyConfigurationExtensions
{
    public static void UseApiKeyAuthorization(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ApiKeyAuthorizationMiddleware>();
    }
}