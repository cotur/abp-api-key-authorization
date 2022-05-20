using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Cotur.Abp.ApiKeyAuthorization.MongoDB;

public static class ApiKeyAuthorizationMongoDbContextExtensions
{
    public static void ConfigureApiKeyAuthorization(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
