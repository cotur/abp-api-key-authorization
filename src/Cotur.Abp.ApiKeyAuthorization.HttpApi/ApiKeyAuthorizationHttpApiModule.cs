using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Cotur.Abp.ApiKeyAuthorization.Core;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Localization.Resources.AbpUi;
using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(ApiKeyAuthorizationApplicationContractsModule),
    typeof(CoturAbpApiKeyAuthorizationCoreModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ApiKeyAuthorizationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ApiKeyAuthorizationHttpApiModule).Assembly);
        });
        
        Configure<ApiKeyResolveOptions>(o =>
        {
            o.ApiKeyResolvers.Add(new HeaderApiKeyResolveContributor());
            o.ApiKeyResolvers.Add(new QueryStringApiKeyResolveContributor());
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ApiKeyAuthorizationResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
