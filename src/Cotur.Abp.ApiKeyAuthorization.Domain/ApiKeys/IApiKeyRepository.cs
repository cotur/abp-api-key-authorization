using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public interface IApiKeyRepository : IBasicRepository<ApiKey, Guid>
{
    Task<ApiKey> FindByKeyAsync(
        [NotNull] string key, 
        bool isActive, 
        bool expireAtCanBeNull = false,
        DateTime? expireAtStart = null, 
        DateTime? expireAtEnd = null, 
        CancellationToken cancellationToken = default);
}