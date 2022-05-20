using Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Cotur.Abp.ApiKeyAuthorization;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ApiKeyAuthorizationEntityFrameworkCoreTestModule)
    )]
public class ApiKeyAuthorizationDomainTestModule : AbpModule
{

}
