using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

public class ApiKeyResolver : IApiKeyResolver, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ApiKeyResolveOptions _options;

    public ApiKeyResolver(IServiceProvider serviceProvider, IOptions<ApiKeyResolveOptions> options)
    {
        _serviceProvider = serviceProvider;
        _options = options.Value;
    }

    public async Task<ApiKeyResolveResult> ResolveApiKeyAsync()
    {
        var result = new ApiKeyResolveResult();

        using (var serviceScope = _serviceProvider.CreateScope())
        {
            var context = new ApiKeyResolveContext(serviceScope.ServiceProvider);

            foreach (var tenantResolver in _options.ApiKeyResolvers)
            {
                await tenantResolver.ResolveAsync(context);

                result.AppliedResolvers.Add(tenantResolver.Name);

                if (context.HasResolvedApiKey())
                {
                    result.ApiKeyValue = context.ApiKeyValue;
                    break;
                }
            }
        }

        return result;
    }
}