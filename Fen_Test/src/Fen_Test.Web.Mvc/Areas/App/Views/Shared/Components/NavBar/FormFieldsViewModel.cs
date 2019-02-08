using Fen_Test.Web.Areas.App.Models.Fields;
using Fen_Test.Web.Areas.App.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Views.Shared.Components.NavBar
{
    public class FormFieldsViewModel
    {
        public int PageId { get; set; }
        public FieldsViewModel FieldsData { get; set; }
        public FormsViewModel FormData { get; set; }
    }
}
