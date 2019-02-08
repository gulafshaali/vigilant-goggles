using Abp.Domain.Entities.Auditing;
using Fen_Test.FormsMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fen_Test.PagesMaster
{
    public class PagesFormsAssociation: FullAuditedEntity<long>
    {
        public virtual Pages Pages { get; set; }
        [ForeignKey("Pages")]
        public long? PagesId { get; set; }
        public virtual Forms Forms { get; set; }
        [ForeignKey("Forms")]
        public long? FormId { get; set; }
    }
}
