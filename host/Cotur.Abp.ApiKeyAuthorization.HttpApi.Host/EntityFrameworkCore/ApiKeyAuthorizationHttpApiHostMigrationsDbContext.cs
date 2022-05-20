using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

public class ApiKeyAuthorizationHttpApiHostMigrationsDbContext : AbpDbContext<ApiKeyAuthorizationHttpApiHostMigrationsDbContext>
{
    public ApiKeyAuthorizationHttpApiHostMigrationsDbContext(DbContextOptions<ApiKeyAuthorizationHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureApiKeyAuthorization();
    }
}
