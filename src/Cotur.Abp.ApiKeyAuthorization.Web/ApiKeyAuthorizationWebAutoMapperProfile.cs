using AutoMapper;
using Cotur.Abp.ApiKeyAuthorization.ApiKeys;

namespace Cotur.Abp.ApiKeyAuthorization.Web;

public class ApiKeyAuthorizationWebAutoMapperProfile : Profile
{
    public ApiKeyAuthorizationWebAutoMapperProfile()
    {
        CreateMap<ApiKeyDto, ApiKeyUpdateDto>();
    }
}
