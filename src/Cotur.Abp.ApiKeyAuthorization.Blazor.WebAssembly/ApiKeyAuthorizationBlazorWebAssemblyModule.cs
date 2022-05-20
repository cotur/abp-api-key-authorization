using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.WebAssembly;

[DependsOn(
    typeof(ApiKeyAuthorizationBlazorModule),
    typeof(ApiKeyAuthorizationHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class ApiKeyAuthorizationBlazorWebAssemblyModule : AbpModule
{

}
