using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(ApiKeyAuthorizationApplicationModule),
    typeof(ApiKeyAuthorizationDomainTestModule)
    )]
public class ApiKeyAuthorizationApplicationTestModule : AbpModule
{

}
