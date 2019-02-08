using Microsoft.AspNetCore.Mvc;
using Fen_Test.Web.Controllers;

namespace Fen_Test.Web.Public.Controllers
{
    public class HomeController : Fen_TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}