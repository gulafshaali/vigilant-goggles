using Fen_Test.Web.Areas.App.Models.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Models.Forms
{
    public class FormsViewModel
    {
        public long? Id { get; set; }
        public string FormName { get; set; }
        public bool status { get; set; }
        public List<FieldsViewModel> FieldsData { get; set; }
    }
}
