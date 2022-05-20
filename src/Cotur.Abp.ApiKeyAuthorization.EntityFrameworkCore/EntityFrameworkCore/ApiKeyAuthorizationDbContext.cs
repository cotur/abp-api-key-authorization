using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

[ConnectionStringName(ApiKeyAuthorizationDbProperties.ConnectionStringName)]
public class ApiKeyAuthorizationDbContext : AbpDbContext<ApiKeyAuthorizationDbContext>, IApiKeyAuthorizationDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ApiKeyAuthorizationDbContext(DbContextOptions<ApiKeyAuthorizationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureApiKeyAuthorization();
    }
}
