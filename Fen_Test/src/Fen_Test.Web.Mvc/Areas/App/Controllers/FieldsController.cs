using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Fen_Test.Authorization.Users;
using Fen_Test.Fields;
using Fen_Test.Fields.Dto;
using Fen_Test.Web.Areas.App.Models.Fields;
using Fen_Test.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fen_Test.Web.Mvc.Areas.App.Controllers
{
    [Area("App")]
    public class FieldsController : Fen_TestControllerBase
    {
        private readonly IFieldsAppService _fieldMasterAppService;
        private readonly IUserRepository _userRepository;
        public FieldsController(IFieldsAppService fieldMasterAppService, IUserRepository userRepository)
        {
            _fieldMasterAppService = fieldMasterAppService;
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            //var data1 = await _userRepository.GetUserNames(1,5);
            ////var te = Json(new { data = data1, total = data1.Count() }).ToString();
            //string output = JsonConvert.SerializeObject(data1);
            //ViewBag.mydata = output;
            var model = new FieldsViewModel
            {
                FilterText = Request.Query["filterText"]
               
            };
            return View(model);
        }


        public async Task<PartialViewResult> CreateOrEditModal(long? id)
        {
            var output = await _fieldMasterAppService.GetFieldsForEdit(new NullableIdDto<long> { Id = id });
            var viewModel = new CreateOrEditFieldsViewModal(output)
            {
                IsEditMode = id.HasValue ? true : false
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

  
        public async Task<ActionResult> GetFieldsList(int pageSize, int skip, string Filtertext,int page)
        {
            var data = await _fieldMasterAppService.GetFieldsList();

            //var data1 = await _userRepository.GetUserNames(page, pageSize);

            data = data.WhereIf(!Filtertext.IsNullOrWhiteSpace(), u => u.FieldName.ToUpper().Contains(Filtertext.ToUpper()) || u.FieldType.ToUpper().Contains(Filtertext.ToUpper())).ToList();





            // Get the total number of records - needed for paging
            var total = data.Count();
            //var total = 50;

            if (pageSize == 0)
            {
                //Show whole list of data
            }
            else
            {

                // Page the data
                data = data.Skip(skip).Take(pageSize).ToList();
            }

            // Return as JSON - the Kendo Grid will use the response
            return Json( new { data = data, total = total });
            //return Json(new { data = data1, total = total });


        }



    }
}