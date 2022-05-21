using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class HeaderApiKeyResolveContributor : HttpApiKeyResolveContributorBase
{
    public const string ContributorName = "Header";

    public override string Name => ContributorName;
    protected override Task<string> GetApiKeyFromHttpContextOrNullAsync(IApiKeyResolveContext context, HttpContext httpContext)
    {
        if (httpContext.Request.Headers.IsNullOrEmpty())
        {
            return Task.FromResult((string)null);
        }

        // TODO: make optional
        var apiKey = "api-key";

        var apiKeyHeader = httpContext.Request.Headers[apiKey];
        if (apiKeyHeader == string.Empty || apiKeyHeader.Count < 1)
        {
            return Task.FromResult((string)null);
        }

        if (apiKeyHeader.Count > 1)
        {
            Log(context, $"HTTP request includes more than one {apiKey} header value. First one will be used. All of them: {apiKeyHeader.JoinAsString(", ")}");
        }

        return Task.FromResult(apiKeyHeader.First());
    }

    protected virtual void Log(IApiKeyResolveContext context, string text)
    {
        context
            .ServiceProvider
            .GetRequiredService<ILogger<HeaderApiKeyResolveContributor>>()
            .LogWarning(text);
    }
}