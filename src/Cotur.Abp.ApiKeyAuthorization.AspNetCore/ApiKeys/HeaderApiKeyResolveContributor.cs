using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class HeaderApiKeyResolveContributor : HttpApiKeyResolveContributorBase
{
    public const string ContributorName = "Header";

    public override string Name => ContributorName;
    protected override Task<string> GetApiKeyFromHttpContextOrNullAsync(IApiKeyResolveContext context, HttpContext httpContext)
    {
        if (httpContext.Request.Headers.IsNullOrEmpty())
        {
            return Task.FromResult(string.Empty);
        }

        var apiKey = httpContext.Request.Headers[context.ApiKeyName];
        if (apiKey == string.Empty || apiKey.Count < 1)
        {
            return Task.FromResult(string.Empty);
        }

        if (apiKey.Count > 1)
        {
            Log(context, $"HTTP request includes more than one {context.ApiKeyName} header value. First one will be used. All of them: {apiKey.JoinAsString(", ")}");
        }

        return Task.FromResult(apiKey.First());
    }

    protected virtual void Log(IApiKeyResolveContext context, string text)
    {
        context
            .ServiceProvider
            .GetRequiredService<ILogger<HeaderApiKeyResolveContributor>>()
            .LogWarning(text);
    }
}