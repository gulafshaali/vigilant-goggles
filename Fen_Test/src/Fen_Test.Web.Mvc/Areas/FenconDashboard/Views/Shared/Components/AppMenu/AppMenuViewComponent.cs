using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Fen_Test.MultiTenancy;
using Fen_Test.Web.Areas.App.Models.Layout;
using Fen_Test.Web.Areas.App.Startup;
using Fen_Test.Web.Areas.FenconDashboard.Satrtup;
using Fen_Test.Web.Theme;
using Fen_Test.Web.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.FenconDashboard.Views.Shared.Components.AppMenu
{
    public class AppMenuViewComponent: Fen_TestViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;
        private readonly TenantManager _tenantManager;
        private readonly IUiThemeCustomizer _uiThemeCustomizer;

        public AppMenuViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession,
            TenantManager tenantManager,
            IUiThemeCustomizer uiThemeCustomizer)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
            _tenantManager = tenantManager;
            _uiThemeCustomizer = uiThemeCustomizer;
        }

        public async Task<IViewComponentResult> InvokeAsync(string currentPageName = null)
        {
            var model = new MenuViewModel
            {
                Menu = await _userNavigationManager.GetMenuAsync(FenconDashboardNavigationProvider.MenuName, _abpSession.ToUserIdentifier()),
                CurrentPageName = currentPageName
            };

            if (AbpSession.TenantId == null)
            {
                return GetView(model);
            }

            var tenant = await _tenantManager.GetByIdAsync(AbpSession.TenantId.Value);
            if (tenant.EditionId.HasValue)
            {
                return GetView(model);
            }

            var subscriptionManagement = FindMenuItemOrNull(model.Menu.Items, AppPageNames.Tenant.SubscriptionManagement);
            if (subscriptionManagement != null)
            {
                subscriptionManagement.IsVisible = false;
            }

            return GetView(model);
        }

        public UserMenuItem FindMenuItemOrNull(IList<UserMenuItem> userMenuItems, string name)
        {
            if (userMenuItems == null)
            {
                return null;
            }

            foreach (var menuItem in userMenuItems)
            {
                if (menuItem.Name == name)
                {
                    return menuItem;
                }

                var found = FindMenuItemOrNull(menuItem.Items, name);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        private IViewComponentResult GetView(MenuViewModel model)
        {
            if (_uiThemeCustomizer.IsLeftMenuUsed)
            {
                return View("Default", model);
            }

            return View("Top", model);
        }
    }
}
