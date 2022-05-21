using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Security.Claims;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeyAuthorization
{
    public class ApiKeyPermissionValueProvider : PermissionValueProvider
    {
        public const string ProviderName = "ApiKey";

        public override string Name => ProviderName;

        private readonly ApiKeyAuthorizationOptions _options;

        public ApiKeyPermissionValueProvider(IPermissionStore permissionStore, IOptions<ApiKeyAuthorizationOptions> options) : base(permissionStore)
        {
            _options = options.Value;
        }

        public override Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
        {
            var authMethod = context.Principal.Identity?.AuthenticationType;

            if (authMethod != "api-key")
            {
                return Task.FromResult(PermissionGrantResult.Undefined);
            }

            var keyInfo = GetApiKeyInfo(context.Principal);

            if (keyInfo == null)
            {
                return Task.FromResult(PermissionGrantResult.Undefined);
            }

            if (keyInfo.GrantAll)
            {
                return Task.FromResult(PermissionGrantResult.Granted);
            }

            if (keyInfo.GrantedPermissions.Contains(context.Permission.Name))
            {
                return Task.FromResult(PermissionGrantResult.Granted);
            }

            return Task.FromResult(PermissionGrantResult.Undefined);
        }

        public override async Task<MultiplePermissionGrantResult> CheckAsync(PermissionValuesCheckContext context)
        {
            var authMethod = context.Principal.Identity?.AuthenticationType;

            if (authMethod != "api-key")
            {
                return new MultiplePermissionGrantResult(context.Permissions.Select(x => x.Name).Distinct().ToArray(), PermissionGrantResult.Undefined);
            }

            var keyInfo = GetApiKeyInfo(context.Principal);

            if (keyInfo == null)
            {
                return new MultiplePermissionGrantResult(context.Permissions.Select(x => x.Name).Distinct().ToArray(), PermissionGrantResult.Undefined);
            }

            if (keyInfo.GrantAll)
            {
                return new MultiplePermissionGrantResult(context.Permissions.Select(x => x.Name).Distinct().ToArray(), PermissionGrantResult.Granted);
            }

            var permissionNames = context.Permissions.Select(x => x.Name).Distinct().ToList();
            var result = new MultiplePermissionGrantResult(permissionNames.ToArray());

            if (keyInfo.GrantedPermissions == null || !keyInfo.GrantedPermissions.Any())
            {
                return result;
            }

            foreach (string keyInfoGrantedPermission in keyInfo.GrantedPermissions)
            {
                permissionNames.Remove(keyInfoGrantedPermission);
            }

            return result;
        }

        private ApiKey GetApiKeyInfo(ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == AbpClaimTypes.UserId);

            if (userId == null)
            {
                return null;
            }

            var keyInfo = _options.KeyInfos.FirstOrDefault(x => x.Claims.FirstOrDefault(y => y.Type == AbpClaimTypes.UserId)?.Value == userId.Value);

            return keyInfo;
        }
    }
}