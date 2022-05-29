using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class ApiKeyResolver : IApiKeyResolver, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ApiKeyResolveOptions _apiKeyResolveOptions;
    private readonly ApiKeyOptions _apiKeyOptions;

    public ApiKeyResolver(
        IServiceProvider serviceProvider, 
        IOptions<ApiKeyResolveOptions> apiKeyResolveOptions, 
        IOptions<ApiKeyOptions> apiKeyOptions)
    {
        _serviceProvider = serviceProvider;
        _apiKeyResolveOptions = apiKeyResolveOptions.Value;
        _apiKeyOptions = apiKeyOptions.Value;
    }

    public virtual async Task<ApiKeyResolveResult> ResolveApiKeyAsync()
    {
        var result = new ApiKeyResolveResult();

        using (var serviceScope = _serviceProvider.CreateScope())
        {
            var context = new ApiKeyResolveContext(serviceScope.ServiceProvider, _apiKeyOptions.ApiKeyName);

            foreach (var apiKeyResolver in _apiKeyResolveOptions.ApiKeyResolvers)
            {
                await apiKeyResolver.ResolveAsync(context);

                result.AppliedResolvers.Add(apiKeyResolver.Name);

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