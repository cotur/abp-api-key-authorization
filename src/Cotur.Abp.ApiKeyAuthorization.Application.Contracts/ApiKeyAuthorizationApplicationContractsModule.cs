using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(ApiKeyAuthorizationDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ApiKeyAuthorizationApplicationContractsModule : AbpModule
{

}
