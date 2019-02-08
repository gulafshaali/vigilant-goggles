using System.Collections.Generic;
using Fen_Test.Authorization.Users.Dto;

namespace Fen_Test.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}