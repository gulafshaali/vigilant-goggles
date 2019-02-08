using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fen_Test.Web.Controllers;

namespace Fen_Test.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : Fen_TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}