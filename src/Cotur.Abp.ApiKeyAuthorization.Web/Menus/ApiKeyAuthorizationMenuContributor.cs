using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Localization;
using Cotur.Abp.ApiKeyAuthorization.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace Cotur.Abp.ApiKeyAuthorization.Web.Menus;

public class ApiKeyAuthorizationMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
        }
        
        await ConfigureMainMenuAsync(context);
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ApiKeyAuthorizationResource>();

        var administration = context.Menu.GetAdministration();
        
        administration.AddItem(new ApplicationMenuItem(ApiKeyAuthorizationMenuNames.ApiKeys, l["ApiKeys"], "~/ApiKeys", "fa fa-key").RequirePermissions(ApiKeyAuthorizationPermissions.ApiKeys.Default));
        
        return Task.CompletedTask;
    }
}
