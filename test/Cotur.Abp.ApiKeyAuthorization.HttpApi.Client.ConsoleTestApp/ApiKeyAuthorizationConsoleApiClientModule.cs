using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ApiKeyAuthorizationHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ApiKeyAuthorizationConsoleApiClientModule : AbpModule
{

}
