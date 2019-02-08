using System.Threading.Tasks;
using Abp.Application.Services;
using Fen_Test.Configuration.Host.Dto;

namespace Fen_Test.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
