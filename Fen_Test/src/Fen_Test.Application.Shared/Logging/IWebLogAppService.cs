using Abp.Application.Services;
using Fen_Test.Dto;
using Fen_Test.Logging.Dto;

namespace Fen_Test.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
