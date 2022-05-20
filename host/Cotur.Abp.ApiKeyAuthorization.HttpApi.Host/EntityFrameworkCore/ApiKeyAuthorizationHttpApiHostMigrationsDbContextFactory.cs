using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

public class ApiKeyAuthorizationHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ApiKeyAuthorizationHttpApiHostMigrationsDbContext>
{
    public ApiKeyAuthorizationHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ApiKeyAuthorizationHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ApiKeyAuthorization"));

        return new ApiKeyAuthorizationHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
