using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cotur.Abp.ApiKeyAuthorization.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
