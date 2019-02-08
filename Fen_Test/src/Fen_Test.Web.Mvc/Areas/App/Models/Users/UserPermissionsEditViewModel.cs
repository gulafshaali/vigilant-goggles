using Abp.AutoMapper;
using Fen_Test.Authorization.Users;
using Fen_Test.Authorization.Users.Dto;
using Fen_Test.Web.Areas.App.Models.Common;

namespace Fen_Test.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}