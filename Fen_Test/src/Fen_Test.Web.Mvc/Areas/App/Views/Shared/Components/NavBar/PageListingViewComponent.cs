using Abp.UI;
using Fen_Test.Authorization.Users;
using Fen_Test.PagesMaster;
using Fen_Test.Web.Views;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.NavBar
{
    public class PagelListingViewComponent: Fen_TestViewComponent
    {
        private readonly IUserRepository _userRepository;
        public PagelListingViewComponent(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            try
            {
                //string formslist = await _userRepository.GetFormsAndFieldsData(Convert.ToInt16(Id));
                //var data = JsonConvert.DeserializeObject(formslist);

                //JArray json = JArray.Parse(formslist);
                //foreach (var jsondata in json)
                //{
                //    var formName = jsondata["FormName"];
                //    var formdata = jsondata["fields"];
                //}
                ////var GetiFrames = json["forms"];
                //FormFieldsViewModel formFields = new FormFieldsViewModel();
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
            return View("~/Areas/App/Views/Shared/Components/NavBar/_FormFieldsData.cshtml");
                
        }
    }
}
