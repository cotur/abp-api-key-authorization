using AutoMapper;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;

namespace Cotur.Abp.ApiKeyAuthorization;

public class ApiKeyAuthorizationApplicationAutoMapperProfile : Profile
{
    public ApiKeyAuthorizationApplicationAutoMapperProfile()
    {
        CreateMap<ApiKey, ApiKeyDto>();
        CreateMap<ApiKeyCreateDto, ApiKey>();
        CreateMap<ApiKeyUpdateDto, ApiKey>();
    }
}
