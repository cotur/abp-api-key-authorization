using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Cotur.Abp.ApiKeyAuthorization.Core;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(CoturAbpApiKeyAuthorizationCoreModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(ApiKeyAuthorizationDomainSharedModule)
)]
public class ApiKeyAuthorizationDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<PermissionManagementOptions>(options =>
        {
            options.ManagementProviders.Add<ApiKeyPermissionManagementProvider>();

           options.ProviderPolicies["ApiKey"] = "ApiKeyAuthorization.ApiKeys.ManagePermissions";
        });
        
        context.Services.AddTransient<IApiKeyStorage, ApiKeyDatabaseStorage>();
    }
}
