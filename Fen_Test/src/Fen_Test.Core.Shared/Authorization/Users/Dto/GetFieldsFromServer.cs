using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.Authorization.Users.Dto
{
    public class GetFieldsFromServer
    {
        //public long Id { get; set; }
        //public string Name { get; set; }
        //public string Type { get; set; }
        //public bool Status { get; set; }

        public long Id { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool Status { get; set; }
    }
}
