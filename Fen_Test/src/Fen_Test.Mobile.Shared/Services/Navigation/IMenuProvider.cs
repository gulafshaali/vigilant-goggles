using System.Collections.Generic;
using MvvmHelpers;
using Fen_Test.Models.NavigationMenu;

namespace Fen_Test.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}