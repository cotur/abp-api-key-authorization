using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Cotur.Abp.ApiKeyAuthorization.Pages;

public abstract class ApiKeyAuthorizationPageModel : AbpPageModel
{
    protected ApiKeyAuthorizationPageModel()
    {
        LocalizationResourceType = typeof(ApiKeyAuthorizationResource);
    }
}
