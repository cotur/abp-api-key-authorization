using Cotur.Abp.ApiKeyAuthorization.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Cotur.Abp.ApiKeyAuthorization.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ApiKeyAuthorizationPageModel : AbpPageModel
{
    protected ApiKeyAuthorizationPageModel()
    {
        LocalizationResourceType = typeof(ApiKeyAuthorizationResource);
        ObjectMapperContext = typeof(ApiKeyAuthorizationWebModule);
    }
}
