using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ApiKeyAuthorizationBlazorModule)
    )]
public class ApiKeyAuthorizationBlazorServerModule : AbpModule
{

}
