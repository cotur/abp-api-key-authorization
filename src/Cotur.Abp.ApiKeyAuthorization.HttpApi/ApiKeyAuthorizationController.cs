using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Cotur.Abp.ApiKeyAuthorization;

public abstract class ApiKeyAuthorizationController : AbpControllerBase
{
    protected ApiKeyAuthorizationController()
    {
        LocalizationResource = typeof(ApiKeyAuthorizationResource);
    }
}
