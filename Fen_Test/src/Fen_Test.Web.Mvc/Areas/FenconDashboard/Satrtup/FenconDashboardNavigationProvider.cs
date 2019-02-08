using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.FenconDashboard.Satrtup
{
    public class FenconDashboardNavigationProvider: NavigationProvider
    {
        public const string MenuName = "FenconDashboard";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            menu
                .AddItem(new MenuItemDefinition(
                        FenconDashboardPageNames.Fencon.Dashboard,
                        L("Dashboard"),
                       // url: "App/HostDashboard",
                        icon: "flaticon-line-graph"
                       // requiredPermissionName: AppPermissions.Pages_Administration_Host_Dashboard
                    )
                ).AddItem(new MenuItemDefinition(
                    FenconDashboardPageNames.Fencon.CV,
                    L("CV"),
                   // url: "App/Tenants",
                    icon: "flaticon-list-3"
                   // requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Fen_TestConsts.LocalizationSourceName);
        }
    }
}
