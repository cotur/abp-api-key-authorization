using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Cotur.Abp.ApiKeyAuthorization.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ApiKeyAuthorizationBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ApiKeyAuthorization";
}
