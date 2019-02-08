using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fen_Test.Web.Session;

namespace Fen_Test.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewComponent : Fen_TestViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AccountLogoViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            return View(new AccountLogoViewModel(loginInfo));
        }
    }
}
