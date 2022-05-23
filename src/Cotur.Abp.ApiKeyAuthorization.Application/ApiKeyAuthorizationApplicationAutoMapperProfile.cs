using AutoMapper;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Volo.Abp.AutoMapper;

namespace Cotur.Abp.ApiKeyAuthorization;

public class ApiKeyAuthorizationApplicationAutoMapperProfile : Profile
{
    public ApiKeyAuthorizationApplicationAutoMapperProfile()
    {
        CreateMap<ApiKey, ApiKeyDto>();
        CreateMap<ApiKeyCreateDto, ApiKey>()
            .IgnoreFullAuditedObjectProperties()
            .Ignore(x => x.Id)
            .Ignore(x => x.ExtraProperties)
            .Ignore(x => x.ConcurrencyStamp)
            .Ignore(x => x.TenantId);
        CreateMap<ApiKeyUpdateDto, ApiKey>()
            .IgnoreFullAuditedObjectProperties()
            .Ignore(x => x.Id)
            .Ignore(x => x.ExtraProperties)
            .Ignore(x => x.ConcurrencyStamp)
            .Ignore(x => x.Key)
            .Ignore(x => x.TenantId);
    }
}
