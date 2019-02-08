using Abp.Domain.Entities.Auditing;
using Fen_Test.FieldsMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fen_Test.FormsMaster
{
    public class FormFields: FullAuditedEntity<long>
    {
       
        public virtual Forms Forms { get; set; }
        [ForeignKey("Forms")]
        public long? FormId { get; set; }
        public virtual FieldMaster Fields { get; set; }
        [ForeignKey("FieldMaster")]
        public long? FieldsId { get; set; }

    }
}
