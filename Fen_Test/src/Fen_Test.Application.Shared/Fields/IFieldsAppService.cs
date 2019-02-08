using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fen_Test.Fields.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Fen_Test.Fields
{
   public  interface IFieldsAppService: IApplicationService
    {
        Task CreateOrUpdateFields(CreateOrUpdateFieldInputMapTo input);
        Task<IList<FieldsListDto>> GetFieldsList();
        Task UpdateStatus(CreateOrUpdateFieldInputMapTo input);
        Task<CreateOrUpdateFieldInputMapTo> GetFieldsForEdit(NullableIdDto<long> input);
    }
}
