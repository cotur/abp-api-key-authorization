using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(ApiKeyAuthorizationApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ApiKeyAuthorizationHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ApiKeyAuthorizationApplicationContractsModule).Assembly,
            ApiKeyAuthorizationRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ApiKeyAuthorizationHttpApiClientModule>();
        });

    }
}
