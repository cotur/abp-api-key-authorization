using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Cotur.Abp.ApiKeyAuthorization.Pages;

public class IndexModel : ApiKeyAuthorizationPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
