using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fen_Test.Web.Areas.App.Models.Layout;
using Fen_Test.Web.Session;
using Fen_Test.Web.Views;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.AppFooter
{
    public class AppFooterViewComponent : Fen_TestViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
