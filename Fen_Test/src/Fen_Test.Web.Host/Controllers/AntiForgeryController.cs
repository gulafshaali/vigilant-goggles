using Microsoft.AspNetCore.Antiforgery;

namespace Fen_Test.Web.Controllers
{
    public class AntiForgeryController : Fen_TestControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
