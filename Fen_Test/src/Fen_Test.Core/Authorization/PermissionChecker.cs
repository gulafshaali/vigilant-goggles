using Abp.Authorization;
using Fen_Test.Authorization.Roles;
using Fen_Test.Authorization.Users;

namespace Fen_Test.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
