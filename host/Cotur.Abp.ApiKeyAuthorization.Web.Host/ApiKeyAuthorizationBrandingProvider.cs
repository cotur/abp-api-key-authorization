using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization;

[Dependency(ReplaceServices = true)]
public class ApiKeyAuthorizationBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ApiKeyAuthorization";
}
