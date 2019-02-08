using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Fen_Test.Authorization.Users;
using Fen_Test.Web.Areas.App.Models.Layout;
using Fen_Test.Web.Areas.App.Models.NavigationBar;
using Fen_Test.Web.Areas.App.Startup;
using Fen_Test.Web.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.NavBar
{
    public class NavBarViewComponent: Fen_TestViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;
        private readonly IUserAppService _userAppService;
        public NavBarViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession,
            IUserAppService userAppService
           )
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
            _userAppService = userAppService;


        }
        public async Task<IViewComponentResult> InvokeAsync(string currentPageName = null)
        {
           
            List<NavBarItemViewModel> navBarItems = new List<NavBarItemViewModel>();
           var pagelist= await _userAppService.GetPagesData();
           
               // navBarItems=pagelist.Select(e => new NavBarItemViewModel(e.PageName,"", "flaticon-line-graph", e.Id)).ToList();

                
            var ViewModel = new NavBarViewModel(navBarItems);
            return View(ViewModel);
           
        }
    }
}
