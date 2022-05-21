using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.AspNetCore.Http;


namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class QueryStringApiKeyResolveContributor : HttpApiKeyResolveContributorBase
{
    public const string ContributorName = "QueryString";
    public override string Name => ContributorName;
    
    protected override Task<string> GetApiKeyFromHttpContextOrNullAsync(IApiKeyResolveContext context, HttpContext httpContext)
    {
        if (httpContext.Request.QueryString.HasValue)
        {
            // TODO: make optional
            var apiKey = "api-key";
            if (httpContext.Request.Query.ContainsKey(apiKey))
            {
                var tenantValue = httpContext.Request.Query[apiKey].ToString();
                if (tenantValue.IsNullOrWhiteSpace())
                {
                    return Task.FromResult<string>(null);
                }

                return Task.FromResult(tenantValue);
            }
        }

        return Task.FromResult<string>(null);
    }
}