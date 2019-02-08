using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.Fields.Dto
{
   public class CreateOrUpdateFieldInput
    {
        public long? Id { get; set; }
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public string Status { get; set; }
    }
}
