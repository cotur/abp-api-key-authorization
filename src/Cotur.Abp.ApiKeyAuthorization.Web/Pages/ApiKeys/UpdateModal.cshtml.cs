using System;
using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Microsoft.AspNetCore.Mvc;

namespace Cotur.Abp.ApiKeyAuthorization.Web.Pages.ApiKeys;

public class UpdateModal : ApiKeyAuthorizationPageModel
{
    [BindProperty(SupportsGet = true)] 
    public Guid Id { get; set; }
    
    [BindProperty]
    public ApiKeyUpdateDto ApiKey { get; set; }

    private readonly IApiKeysAppService _apiKeysAppService;

    public UpdateModal(IApiKeysAppService apiKeysAppService)
    {
        _apiKeysAppService = apiKeysAppService;
    }

    public async Task OnGetAsync()
    {
        ApiKey = ObjectMapper.Map<ApiKeyDto, ApiKeyUpdateDto>(await _apiKeysAppService.GetAsync(Id));
    }
    
    public Task OnPostAsync()
    {
        return _apiKeysAppService.UpdateAsync(Id, ApiKey);
    }
}