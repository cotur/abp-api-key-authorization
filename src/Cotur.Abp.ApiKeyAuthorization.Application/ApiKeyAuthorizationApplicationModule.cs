using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Cotur.Abp.ApiKeyAuthorization;

[DependsOn(
    typeof(ApiKeyAuthorizationDomainModule),
    typeof(ApiKeyAuthorizationApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class ApiKeyAuthorizationApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ApiKeyAuthorizationApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApiKeyAuthorizationApplicationModule>(validate: true);
        });
    }
}
