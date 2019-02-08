using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fen_Test.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fen_Test.Web.Mvc.Areas.App.Controllers
{
    [Area("App")]
    public class FormController : Fen_TestControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<PartialViewResult> AddFormFields(long? id)
        {
           

            return PartialView("_AddFormFields");
        }
    }
}