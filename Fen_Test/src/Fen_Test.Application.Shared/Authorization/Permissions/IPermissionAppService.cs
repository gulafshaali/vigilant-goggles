using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fen_Test.Authorization.Permissions.Dto;

namespace Fen_Test.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
