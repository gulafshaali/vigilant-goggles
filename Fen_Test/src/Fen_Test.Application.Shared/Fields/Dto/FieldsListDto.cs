using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.Fields.Dto
{
  public  class FieldsListDto
    {
        public long? Id { get; set; }
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public bool Status { get; set; }
    }
}
