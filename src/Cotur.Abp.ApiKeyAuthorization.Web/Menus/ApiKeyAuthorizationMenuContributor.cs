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

        // todo add to identity
        var identityMenuItem = context.Menu.GetAdministration();
        
        identityMenuItem.AddItem(new ApplicationMenuItem(ApiKeyAuthorizationMenuNames.ApiKeys, l["ApiKeys"], "~/Identity/ApiKeys", "fa fa-key-o").RequirePermissions(ApiKeyAuthorizationPermissions.ApiKeys.Default));
        
        return Task.CompletedTask;
    }
}
