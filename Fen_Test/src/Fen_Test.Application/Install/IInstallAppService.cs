using System.Threading.Tasks;
using Abp.Application.Services;
using Fen_Test.Install.Dto;

namespace Fen_Test.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}