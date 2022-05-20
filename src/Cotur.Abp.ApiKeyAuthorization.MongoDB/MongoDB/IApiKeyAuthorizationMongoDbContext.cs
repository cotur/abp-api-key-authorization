using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Cotur.Abp.ApiKeyAuthorization.MongoDB;

[ConnectionStringName(ApiKeyAuthorizationDbProperties.ConnectionStringName)]
public interface IApiKeyAuthorizationMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
