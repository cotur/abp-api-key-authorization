using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization.Core;

[DependsOn(
    typeof(AbpAuthorizationAbstractionsModule)
    )]
public class CoturAbpApiKeyAuthorizationCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpPermissionOptions>(opt =>
        {
            opt.ValueProviders.Add<ApiKeyPermissionValueProvider>();
        });
    }
}