using Volo.Abp.Bundling;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.Host;

public class ApiKeyAuthorizationBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
