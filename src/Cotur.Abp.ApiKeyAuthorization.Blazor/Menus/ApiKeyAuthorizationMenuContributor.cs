using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.Menus;

public class ApiKeyAuthorizationMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ApiKeyAuthorizationMenus.Prefix, displayName: "ApiKeyAuthorization", "/ApiKeyAuthorization", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
