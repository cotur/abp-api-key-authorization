using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;
using Microsoft.AspNetCore.Http;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Cotur.Abp.ApiKeyAuthorization.Http.ApiKeys;

public class ApiKeyAuthorizationMiddleware : IMiddleware, ITransientDependency
{
    private readonly IApiKeyResolver _apiKeyResolver;
    private readonly IApiKeyPrincipleProvider _apiKeyPrincipleProvider;
    private readonly ICurrentUser _currentUser;

    public ApiKeyAuthorizationMiddleware(
        IApiKeyResolver apiKeyResolver,
        IApiKeyPrincipleProvider apiKeyPrincipleProvider,
        ICurrentUser currentUser)
    {
        _apiKeyResolver = apiKeyResolver;
        _apiKeyPrincipleProvider = apiKeyPrincipleProvider;
        _currentUser = currentUser;
    }

    public virtual async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (_currentUser.IsAuthenticated)
        {
            await next(context);
            return;
        }
        
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
        
        context.User = principal;
        
        await next(context);
    }
}