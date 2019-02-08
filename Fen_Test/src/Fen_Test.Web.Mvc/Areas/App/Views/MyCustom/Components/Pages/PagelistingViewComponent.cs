using Abp.UI;
using Fen_Test.Authorization.Users;
using Fen_Test.Web.Areas.App.Models.Fields;
using Fen_Test.Web.Areas.App.Models.Forms;
using Fen_Test.Web.Areas.App.Views.MyCustom.Components.Pages;
using Fen_Test.Web.Views;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.MyCustom.Components.CustomPages
{
    public class PagelistingViewComponent: Fen_TestViewComponent
    {
        private readonly IUserRepository _userRepository;
        public PagelistingViewComponent(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            try
            {
                string formslist = await _userRepository.GetFormsAndFieldsData(Convert.ToInt16(Id));
                
             
              
                FormFieldsViewModel ViewModelObj = new FormFieldsViewModel();
                #region Fetch All the Forms Available in Page
                // Fetch All the forms In the Pages
                JArray json = JArray.Parse(formslist);
            
                List<FormsViewModel> FormsData = new List<FormsViewModel>();
                foreach (var jsondata in json)
                {
                    FormsViewModel Forms = new FormsViewModel();
                    Forms.FormName=jsondata["FormName"].ToString();
                    Forms.Id = Convert.ToInt64(jsondata["Id"].ToString());
                    #region get Fields available in  the form
                    // Fetch All the fields In the Forms
                    List<FieldsViewModel> FieldsJson = new List<FieldsViewModel>();
                    JArray Fieldjson = JArray.Parse(jsondata["fields"].ToString());
                    foreach (var data1 in Fieldjson)
                    {
                        FieldsViewModel fields = new FieldsViewModel();
                        fields.FieldId = Convert.ToInt64(data1["Id"].ToString());
                        fields.FieldsName = data1["Name"].ToString();
                        FieldsJson.Add(fields);
                        Forms.FieldsData = FieldsJson;
                    }
                    #endregion get Fields available in  the form
                    FormsData.Add(Forms);
                    ViewModelObj.FormData = FormsData;
                    ViewModelObj.PageId = Convert.ToInt32(Id);
                }

                #endregion Fetch All the Forms Available in Page

                return View("~/Areas/App/Views/MyCustom/Components/Pages/_FormFieldsData.cshtml", ViewModelObj);

            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
           
        }
    }
}
