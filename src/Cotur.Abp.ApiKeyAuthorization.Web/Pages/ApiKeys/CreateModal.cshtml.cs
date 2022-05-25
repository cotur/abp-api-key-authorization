using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Microsoft.AspNetCore.Mvc;

namespace Cotur.Abp.ApiKeyAuthorization.Web.Pages.ApiKeys;

public class CreateModal : ApiKeyAuthorizationPageModel
{
    [BindProperty]
    public ApiKeyCreateDto ApiKey { get; set; }

    private readonly IApiKeysAppService _apiKeysAppService;

    public CreateModal(IApiKeysAppService apiKeysAppService)
    {
        _apiKeysAppService = apiKeysAppService;
    }

    public Task OnPostAsync()
    {
        return _apiKeysAppService.CreateAsync(ApiKey);
    }
}