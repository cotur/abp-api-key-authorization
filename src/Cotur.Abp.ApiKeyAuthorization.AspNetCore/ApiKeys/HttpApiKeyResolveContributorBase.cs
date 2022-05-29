using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public abstract class HttpApiKeyResolveContributorBase : ApiKeyResolveContributorBase
{
    public override async Task ResolveAsync(IApiKeyResolveContext context)
    {
        var httpContext = context.GetHttpContext();
        if (httpContext == null)
        {
            return;
        }

        try
        {
            await ResolveFromHttpContextAsync(context, httpContext);
        }
        catch (Exception e)
        {
            context.ServiceProvider
                .GetRequiredService<ILogger<HttpApiKeyResolveContributorBase>>()
                .LogWarning(e.ToString());
        }
    }
    
    protected virtual async Task ResolveFromHttpContextAsync(IApiKeyResolveContext context, HttpContext httpContext)
    {
        var apiKeyValue = await GetApiKeyFromHttpContextOrNullAsync(context, httpContext);
        if (!apiKeyValue.IsNullOrEmpty())
        {
            context.ApiKeyValue = apiKeyValue;
        }
    }
    
    protected abstract Task<string> GetApiKeyFromHttpContextOrNullAsync([NotNull] IApiKeyResolveContext context, [NotNull] HttpContext httpContext);
}