using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Cotur.Abp.ApiKeyAuthorization.MongoDB;

[ConnectionStringName(ApiKeyAuthorizationDbProperties.ConnectionStringName)]
public class ApiKeyAuthorizationMongoDbContext : AbpMongoDbContext, IApiKeyAuthorizationMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureApiKeyAuthorization();
    }
}
