using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fen_Test.PagesMaster
{
    public class Pages: FullAuditedEntity<long>
    {
        public string PageName { get; set; }
        public bool PageStatus { get; set; }
       
    }
}
