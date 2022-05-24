using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class EfCoreApiKeysRepository : EfCoreRepository<ApiKeyAuthorizationDbContext, ApiKey, Guid>, IApiKeyRepository
{
    public EfCoreApiKeysRepository(IDbContextProvider<ApiKeyAuthorizationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<ApiKey> FindByKeyAsync(
        string key,
        bool isActive, 
        bool expireAtCanBeNull = false,
        DateTime? expireAtStart = null,
        DateTime? expireAtEnd = null,
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        var query = dbSet.Where(x => x.Key == key)
            .Where(x => x.Active == isActive)
            .WhereIf(expireAtStart.HasValue, x => expireAtCanBeNull ? x.ExpireAt == null || x.ExpireAt >= expireAtStart : x.ExpireAt >= expireAtStart)
            .WhereIf(expireAtEnd.HasValue, x => expireAtCanBeNull ? x.ExpireAt == null || x.ExpireAt <= expireAtEnd : x.ExpireAt <= expireAtEnd);
        
        return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }
}