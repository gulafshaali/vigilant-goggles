using Abp.Application.Navigation;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.AppMenu
{
    public class UserMenuItemViewModel
    {
        public UserMenuItem MenuItem { get; set; }

        public string CurrentPageName { get; set; }

        public int MenuItemIndex { get; set; }

        public bool RootLevel { get; set; }
    }
}
