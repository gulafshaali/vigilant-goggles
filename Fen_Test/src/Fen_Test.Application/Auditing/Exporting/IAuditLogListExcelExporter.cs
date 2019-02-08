using System.Collections.Generic;
using Fen_Test.Auditing.Dto;
using Fen_Test.Dto;

namespace Fen_Test.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
