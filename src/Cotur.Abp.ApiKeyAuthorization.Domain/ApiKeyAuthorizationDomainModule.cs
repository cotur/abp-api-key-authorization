using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ApiKeyAuthorizationDomainSharedModule)
)]
public class ApiKeyAuthorizationDomainModule : AbpModule
{

}
