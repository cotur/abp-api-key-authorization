using AutoMapper;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;
using Cotur.Abp.ApiKeyAuthorization.Core.ApiKeys;

namespace Cotur.Abp.ApiKeyAuthorization;

public class ApiKeyAuthorizationDomainAutoMapperProfile : Profile
{
    public ApiKeyAuthorizationDomainAutoMapperProfile()
    {
        CreateMap<ApiKey, ApiKeyInfo>()
            .ForMember(d => d.Id, e => e.MapFrom(s => s.Id.ToString()))
            .ForMember(d => d.TenantId, e => e.MapFrom(s => s.TenantId == null ? string.Empty : s.TenantId.ToString()));
    }
}
