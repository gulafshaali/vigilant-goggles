using Fen_Test.Web.Areas.App.Models.Fields;
using Fen_Test.Web.Areas.App.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.MyCustom.Components.Pages
{
    public class FormFieldsViewModel
    {
        public int PageId { get; set; }
        //public List<FieldsViewModel> FieldsData { get; set; }
        public List<FormsViewModel> FormData { get; set; }
        public string FormName { get; set; }
        public string FieldData { get; set; }
    }
}
