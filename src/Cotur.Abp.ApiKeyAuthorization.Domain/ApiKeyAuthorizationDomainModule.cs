using Cotur.Abp.ApiKeyAuthorization.Core;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(CoturAbpApiKeyAuthorizationCoreModule),
    typeof(ApiKeyAuthorizationDomainSharedModule)
)]
public class ApiKeyAuthorizationDomainModule : AbpModule
{

}
