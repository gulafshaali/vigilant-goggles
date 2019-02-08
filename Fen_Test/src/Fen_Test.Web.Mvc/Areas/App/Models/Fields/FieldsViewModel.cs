using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Models.Fields
{
    public class FieldsViewModel
    {
        public string FilterText { get; set; }
        public string FieldsName { get; set; }
        public long? FieldId { get; set; }
        public int FieldType { get; set; }
    }
}
