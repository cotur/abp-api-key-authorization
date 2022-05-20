using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.Application.Services;

namespace Cotur.Abp.ApiKeyAuthorization;

public abstract class ApiKeyAuthorizationAppService : ApplicationService
{
    protected ApiKeyAuthorizationAppService()
    {
        LocalizationResource = typeof(ApiKeyAuthorizationResource);
        ObjectMapperContext = typeof(ApiKeyAuthorizationApplicationModule);
    }
}
