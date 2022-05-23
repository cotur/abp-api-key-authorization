using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

[DependsOn(
    typeof(ApiKeyAuthorizationDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ApiKeyAuthorizationEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ApiKeyAuthorizationDbContext>(options =>
        {
            options.AddDefaultRepositories<IApiKeyAuthorizationDbContext>(includeAllEntities: true);
            
            options.AddRepository<ApiKey, EfCoreApiKeysRepository>();
        });

        context.Services.AddTransient<IApiKeyRepository, EfCoreApiKeysRepository>();
    }
}
