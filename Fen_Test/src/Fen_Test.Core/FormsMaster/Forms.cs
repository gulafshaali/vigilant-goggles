using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.FormsMaster
{
    public class Forms: FullAuditedEntity<long>
    {
        public string FormName { get; set; }
        public bool FormStatus { get; set; }
    }
}
