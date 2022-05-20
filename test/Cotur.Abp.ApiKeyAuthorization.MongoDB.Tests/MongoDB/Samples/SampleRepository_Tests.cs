using Cotur.Abp.ApiKeyAuthorization.Samples;
using Xunit;

namespace Cotur.Abp.ApiKeyAuthorization.MongoDB.Samples;

[Collection(MongoTestCollection.Name)]
public class SampleRepository_Tests : SampleRepository_Tests<ApiKeyAuthorizationMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
}
