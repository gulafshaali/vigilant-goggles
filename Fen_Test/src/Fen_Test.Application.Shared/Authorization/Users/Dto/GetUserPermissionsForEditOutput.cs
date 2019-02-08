using System.Collections.Generic;
using Fen_Test.Authorization.Permissions.Dto;

namespace Fen_Test.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}