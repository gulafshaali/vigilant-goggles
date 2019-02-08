using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.FieldsMaster
{
    public class FieldMaster: FullAuditedEntity<long>
    {
       
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
