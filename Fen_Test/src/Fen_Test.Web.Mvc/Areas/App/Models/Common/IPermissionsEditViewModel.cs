using System.Collections.Generic;
using Fen_Test.Authorization.Permissions.Dto;

namespace Fen_Test.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}