using System;
using System.Threading.Tasks;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public interface IApiKeyStorage
{
    Task<ApiKey> GetOrNullAsync(Guid id);
}