using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

[ConnectionStringName(ApiKeyAuthorizationDbProperties.ConnectionStringName)]
public interface IApiKeyAuthorizationDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
