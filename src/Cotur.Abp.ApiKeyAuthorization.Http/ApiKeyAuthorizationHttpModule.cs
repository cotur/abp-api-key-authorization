using Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization.Http;

[DependsOn(
    typeof(AbpAspNetCoreMvcModule)
    )]
public class ApiKeyAuthorizationHttpModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        
        Configure<ApiKeyOptions>(configuration.GetSection("apiKeys"));
        
        Configure<ApiKeyResolveOptions>(o =>
        {
            o.ApiKeyResolvers.Add(new HeaderApiKeyResolveContributor());
            o.ApiKeyResolvers.Add(new QueryStringApiKeyResolveContributor());
        });
    }
}