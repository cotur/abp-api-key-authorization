using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;

[ConnectionStringName(ApiKeyAuthorizationDbProperties.ConnectionStringName)]
public interface IApiKeyAuthorizationDbContext : IEfCoreDbContext
{
    DbSet<ApiKey> ApiKeys { get; }
}
