using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Fen_Test.Web.Controllers
{
    public class HomeController : Fen_TestControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
