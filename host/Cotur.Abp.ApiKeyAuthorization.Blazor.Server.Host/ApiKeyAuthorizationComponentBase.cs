using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.Server.Host;

public abstract class ApiKeyAuthorizationComponentBase : AbpComponentBase
{
    protected ApiKeyAuthorizationComponentBase()
    {
        LocalizationResource = typeof(ApiKeyAuthorizationResource);
    }
}
