using System.Threading.Tasks;
using Abp.Application.Services;
using Fen_Test.Configuration.Tenants.Dto;

namespace Fen_Test.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
