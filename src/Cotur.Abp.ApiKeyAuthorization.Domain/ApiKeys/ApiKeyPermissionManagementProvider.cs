using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyPermissionManagementProvider : PermissionManagementProvider
{
    public override string Name => "ApiKey";
    
    public ApiKeyPermissionManagementProvider(
        IPermissionGrantRepository permissionGrantRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant) 
        : base(permissionGrantRepository, guidGenerator, currentTenant)
    {
    }
}