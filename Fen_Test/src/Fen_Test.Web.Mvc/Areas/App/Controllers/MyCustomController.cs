using Abp.UI;
using Fen_Test.Authorization.Users;
using Fen_Test.EntityFrameworkCore;
using Fen_Test.FormsMaster;
using Fen_Test.PagesMaster;
using Fen_Test.Web.Areas.App.Models.Fields;
using Fen_Test.Web.Areas.App.Models.Forms;
using Fen_Test.Web.Areas.App.Models.MyCustom;
using Fen_Test.Web.Areas.App.Models.NavigationBar;
using Fen_Test.Web.Areas.App.Views.MyCustom.Components.Pages;
using Fen_Test.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Controllers
{
    [Area("App")]
    public class MyCustomController:  Fen_TestControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IUserRepository _userRepository;
        //private readonly UserManager _userManager;
        public MyCustomController(IPageManager pageManager, IUserAppService userAppService, IUserRepository userRepository)
        {
            _userAppService = userAppService;
            _userRepository = userRepository;
            // _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
          
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            //var usernames=await _userAppService.GetUsersNames();
            var usernames = await _userAppService.GetPagesData();
            watch.Stop();
            ViewBag.Names = usernames;
            ViewBag.TimeConsumed=($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return View();
        }
        public ActionResult GetUserByDefaultRepository()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var usernames =  _userAppService.GetAllUsers();
            watch.Stop();

            ViewBag.Names = usernames;
            ViewBag.TimeConsumed = ($"Execution Time: {watch.ElapsedMilliseconds} ms");
            return View();
        }
        public async Task<PartialViewResult> MyCustomView(string name)
        {

            ViewBag.Name = name;
            return PartialView("_MyCustomView");
        }
        //public PartialViewResult MyCustomSideBar(string Id)
        public IActionResult MyCustomSideBar(string Id) 
        {
            
            return ViewComponent("Pagelisting", Id);
           
        }
        // Comment this code while using View Component for the same logic as it throws exception due to shared model
        public async Task<ActionResult> ReportPage()
        {
            List<NavBarItemViewModel> navBarItems = new List<NavBarItemViewModel>();
            var pagelist = await _userAppService.GetPagesData();

            NavBarViewModel ViewModel = null;
            foreach (var page in pagelist)
            {
                // page listing View Component logic
                var NavBarItemViewModel = new NavBarItemViewModel();
                try
                {
                    string formslist = await _userRepository.GetFormsAndFieldsData(Convert.ToInt16(page.Id));
                    if (!string.IsNullOrEmpty(formslist))
                    {
                        #region Fetch All the Forms Available in Page
                        // Fetch All the forms In the Pages
                        JArray json = JArray.Parse(formslist);

                        List<FormsViewModel> FormsData = new List<FormsViewModel>();
                        foreach (var jsondata in json)
                        {
                            FormsViewModel Forms = new FormsViewModel();
                            Forms.FormName = jsondata["FormName"].ToString();
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
                                fields.FieldType = Convert.ToInt32(data1["Type"].ToString());
                                FieldsJson.Add(fields);
                                Forms.FieldsData = FieldsJson;
                            }
                            #endregion get Fields available in  the form
                            FormsData.Add(Forms);

                        }
                        #endregion Fetch All the Forms Available in Page
                        NavBarItemViewModel.Id = page.Id;
                        NavBarItemViewModel.Text = page.PageName;
                        NavBarItemViewModel.Icon = "flaticon-line-graph";
                        NavBarItemViewModel.FormsList = FormsData;
                        navBarItems.Add(NavBarItemViewModel);

                        ViewModel = new NavBarViewModel(navBarItems);
                    }
                }
                catch (Exception e)
                {
                    throw new UserFriendlyException(e.Message);
                }
            }
            return View(ViewModel);


        }

        public async Task<ActionResult> GetFieldsByFormAndPageId(int formId, int pageId)
        {
            try
            {
                string fieldList = await _userRepository.GetFieldsDataFromPageAndFormId(Convert.ToInt64(formId), Convert.ToInt64(pageId));
                if (!string.IsNullOrEmpty(fieldList))
                {

                    return Json(new { data = fieldList });

                }
                return Json(new { data = "" });
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }


        
    }
}
