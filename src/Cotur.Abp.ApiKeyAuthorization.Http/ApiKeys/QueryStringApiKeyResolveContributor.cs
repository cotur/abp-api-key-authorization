using Microsoft.AspNetCore.Http;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class QueryStringApiKeyResolveContributor : HttpApiKeyResolveContributorBase
{
    public const string ContributorName = "QueryString";
    public override string Name => ContributorName;
    
    protected override Task<string> GetApiKeyFromHttpContextOrNullAsync(IApiKeyResolveContext context, HttpContext httpContext)
    {
        if (httpContext.Request.QueryString.HasValue)
        {
            if (httpContext.Request.Query.ContainsKey(context.ApiKeyName))
            {
                var apiKey = httpContext.Request.Query[context.ApiKeyName].ToString();
                if (apiKey.IsNullOrWhiteSpace())
                {
                    return Task.FromResult(string.Empty);
                }

                return Task.FromResult(apiKey);
            }
        }

        return Task.FromResult(string.Empty);
    }
}