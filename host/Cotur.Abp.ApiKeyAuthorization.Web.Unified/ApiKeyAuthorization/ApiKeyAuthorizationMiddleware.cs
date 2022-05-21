using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.ApiKeyAuthorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

public class ApiKeyAuthorizationMiddleware : IMiddleware, ITransientDependency
{
    private readonly ApiKeyAuthorizationOptions _options;

    public ApiKeyAuthorizationMiddleware(IOptions<ApiKeyAuthorizationOptions> options)
    {
        _options = options.Value;
    }

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!_options.KeyInfos.Any())
        {
            return next(context);
        }

        var apiKeyInfo = GetInfoOrNull(context);

        if (apiKeyInfo == null)
        {
            return next(context);
        }
        
        context.User = new ClaimsPrincipal(
            new ClaimsIdentity(apiKeyInfo.Claims, "api-key", AbpClaimTypes.UserName, AbpClaimTypes.Role)
        );
        
        return next(context);
    }

    private ApiKey GetInfoOrNull(HttpContext context)
    {
        foreach (var apiKeyInfo in _options.KeyInfos)
        {
            if (context.Request.Query[apiKeyInfo.Key] == apiKeyInfo.Value ||
                context.Request.Headers[apiKeyInfo.Key] == apiKeyInfo.Value)
            {
                return apiKeyInfo;
            }
        }

        return null;
    }
}