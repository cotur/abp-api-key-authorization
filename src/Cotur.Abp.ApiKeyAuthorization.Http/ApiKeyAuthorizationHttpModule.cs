using Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;
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
        Configure<ApiKeyOptions>(o =>
        {
            o.ApiKeyName = "api-key";
        });
        
        Configure<ApiKeyResolveOptions>(o =>
        {
            o.ApiKeyResolvers.Add(new HeaderApiKeyResolveContributor());
            o.ApiKeyResolvers.Add(new QueryStringApiKeyResolveContributor());
        });
    }
}