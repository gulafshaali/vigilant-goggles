using Fen_Test.Web.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.Confirmation
{
    public class ConfirmationViewComponent: Fen_TestViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            ViewBag.msg = id.Value;

            return View();
        }
    }
}
