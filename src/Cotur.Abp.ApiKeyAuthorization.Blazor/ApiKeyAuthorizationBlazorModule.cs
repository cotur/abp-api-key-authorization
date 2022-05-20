using Microsoft.Extensions.DependencyInjection;
using Cotur.Abp.ApiKeyAuthorization.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor;

[DependsOn(
    typeof(ApiKeyAuthorizationApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class ApiKeyAuthorizationBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ApiKeyAuthorizationBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<ApiKeyAuthorizationBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ApiKeyAuthorizationMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(ApiKeyAuthorizationBlazorModule).Assembly);
        });
    }
}
