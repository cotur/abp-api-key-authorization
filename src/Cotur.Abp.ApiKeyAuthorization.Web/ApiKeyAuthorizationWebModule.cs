using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Cotur.Abp.ApiKeyAuthorization.Localization;
using Cotur.Abp.ApiKeyAuthorization.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Cotur.Abp.ApiKeyAuthorization.Permissions;

namespace Cotur.Abp.ApiKeyAuthorization.Web;

[DependsOn(
    typeof(ApiKeyAuthorizationApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class ApiKeyAuthorizationWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(ApiKeyAuthorizationResource), typeof(ApiKeyAuthorizationWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ApiKeyAuthorizationWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ApiKeyAuthorizationMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ApiKeyAuthorizationWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<ApiKeyAuthorizationWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApiKeyAuthorizationWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
                //Configure authorization.
            });
    }
}
