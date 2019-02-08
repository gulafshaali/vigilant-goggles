using System.Collections.Generic;
using Fen_Test.Authorization.Users.Dto;
using Fen_Test.Dto;

namespace Fen_Test.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}