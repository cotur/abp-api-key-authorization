using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Cotur.Abp.ApiKeyAuthorization.MongoDB;

[DependsOn(
    typeof(ApiKeyAuthorizationDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ApiKeyAuthorizationMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ApiKeyAuthorizationMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
