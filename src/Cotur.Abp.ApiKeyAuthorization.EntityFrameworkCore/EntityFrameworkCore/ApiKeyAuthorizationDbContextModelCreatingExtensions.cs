using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

public static class ApiKeyAuthorizationDbContextModelCreatingExtensions
{
    public static void ConfigureApiKeyAuthorization(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<ApiKey>(b =>
        {
            b.ToTable(ApiKeyAuthorizationDbProperties.DbTablePrefix + "ApiKeys", ApiKeyAuthorizationDbProperties.DbSchema);
            
            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(ApiKeyConsts.MaxNameLength);
            b.Property(x => x.Key).IsRequired().HasMaxLength(ApiKeyConsts.MaxKeyLength);
            b.Property(x => x.Active).IsRequired();
            
            b.HasIndex(x => x.Key).IsUnique();
            b.HasIndex(x => new {x.Key, x.Active, x.ExpireAt}).IsUnique();
        });
    }
}
