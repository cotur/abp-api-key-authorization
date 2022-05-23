using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cotur.Abp.ApiKeyAuthorization.Web.Pages.ApiKeys;

public class IndexModel : ApiKeyAuthorizationPageModel
{
    public virtual Task<IActionResult> OnGetAsync()
    {
        return Task.FromResult<IActionResult>(Page());
    }

    public virtual Task<IActionResult> OnPostAsync()
    {
        return Task.FromResult<IActionResult>(Page());
    }
}
