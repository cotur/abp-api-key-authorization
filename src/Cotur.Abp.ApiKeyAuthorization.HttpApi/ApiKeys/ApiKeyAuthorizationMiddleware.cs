using System.Threading.Tasks;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.AspNetCore.Http;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyAuthorizationMiddleware : IMiddleware, ITransientDependency
{
    private readonly IApiKeyResolver _apiKeyResolver;
    private readonly IApiKeyPrincipleProvider _apiKeyPrincipleProvider;
    private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;

    public ApiKeyAuthorizationMiddleware(
        IApiKeyResolver apiKeyResolver,
        IApiKeyPrincipleProvider apiKeyPrincipleProvider,
        ICurrentPrincipalAccessor currentPrincipalAccessor)
    {
        _apiKeyResolver = apiKeyResolver;
        _apiKeyPrincipleProvider = apiKeyPrincipleProvider;
        _currentPrincipalAccessor = currentPrincipalAccessor;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var apiKeyResult = await _apiKeyResolver.ResolveApiKeyAsync();

        if (string.IsNullOrWhiteSpace(apiKeyResult.ApiKeyValue))
        {
            await next(context);
            return;
        }

        var principal = await _apiKeyPrincipleProvider.GetApiKeyPrincipleOrNullAsync(apiKeyResult.ApiKeyValue);

        if (principal == null)
        {
            await next(context);
            return;
        }

        using (_currentPrincipalAccessor.Change(principal))
        {
            await next(context);
        }
    }
}