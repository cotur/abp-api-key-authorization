using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class ApiKeyAuthorizationDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ApiKeyAuthorizationDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<ApiKeyAuthorizationResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/ApiKeyAuthorization");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("ApiKeyAuthorization", typeof(ApiKeyAuthorizationResource));
        });
    }
}
