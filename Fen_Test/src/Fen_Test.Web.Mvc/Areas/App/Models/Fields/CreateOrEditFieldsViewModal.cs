using Abp.AutoMapper;
using Fen_Test.Fields.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Models.Fields
{
    [AutoMapFrom(typeof(CreateOrUpdateFieldInputMapTo))]
    public class CreateOrEditFieldsViewModal: CreateOrUpdateFieldInputMapTo
    {
        public bool IsEditMode
        {
            get;set;
        }
        public CreateOrEditFieldsViewModal(CreateOrUpdateFieldInputMapTo output)
        {
            output.MapTo(this);
        }
        //public long Id { get; set; }
        //public string FieldName { get; set; }

        //public string FieldType { get; set; }

        //public string Status { get; set; }
    }
}
