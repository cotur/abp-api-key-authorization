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
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
