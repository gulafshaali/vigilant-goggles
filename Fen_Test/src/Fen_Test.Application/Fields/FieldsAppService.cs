using Abp.Application.Services.Dto;
using Abp.UI;
using Fen_Test.Fields.Dto;
using Fen_Test.FieldsMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.Fields
{
    public class FieldsAppService: Fen_TestAppServiceBase, IFieldsAppService
    {
        private readonly IFieldMasterManager _fieldMasterManager;
        public FieldsAppService(IFieldMasterManager fieldMasterManager)
        {
            _fieldMasterManager = fieldMasterManager;
        }
        public async Task CreateOrUpdateFields(CreateOrUpdateFieldInputMapTo input)
        {
            if (input.input.Id.HasValue)
            {
                await UpdateFieldsAsync(input);
            }
            else
            {
                await CreateFieldsAsync(input);
            }
        }
        protected virtual async Task UpdateFieldsAsync(CreateOrUpdateFieldInputMapTo input)
        {
           

           
        }
        protected virtual async Task CreateFieldsAsync(CreateOrUpdateFieldInputMapTo input)
        {
            try
            {
                FieldMaster fieldObject = new FieldMaster();
                fieldObject.Name = input.input.FieldName;
                fieldObject.Type = input.input.FieldType;
                fieldObject.Status = input.input.Status == "Active" ? true : false;
               var AlreadyExistfield= await _fieldMasterManager.GetFieldsAsync(fieldObject);
                if (AlreadyExistfield!=null)
                {
                    throw new UserFriendlyException(L("FieldAlreadyExist"));
                }
                await _fieldMasterManager.CreateFieldsAsync(fieldObject);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }
        public async Task<IList<FieldsListDto>> GetFieldsList()
        {
            try
            {
                var FieldsListDtos = new List<FieldsListDto>();
                var fieldata = await _fieldMasterManager.GetFieldsListAsync();
                FieldsListDtos =
              (from ou in fieldata              
              select new FieldsListDto {
                  Id=ou.Id,
                  FieldName =ou.Name,
                  FieldType=ou.Type=="1"?"Text Box": "Text Area",
                  Status=ou.Status
              }).ToList();
                return FieldsListDtos;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }
        public async Task UpdateStatus(CreateOrUpdateFieldInputMapTo input)
        {
            try
            {
                var field = await _fieldMasterManager.GetFieldByIdAsync(input.input.Id.Value);
             
                field.Status = input.input.Status == "true" ? true : false;
                await _fieldMasterManager.UpdateFieldStatus(field);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }
        public async Task<CreateOrUpdateFieldInputMapTo> GetFieldsForEdit(NullableIdDto<long> input)
        {
            CreateOrUpdateFieldInputMapTo output = null; 



            if (!input.Id.HasValue)
            {
                //Creating a new Field
                output = new CreateOrUpdateFieldInputMapTo
                {
                    input = new CreateOrUpdateFieldInput { Status = "true" }
                   
                };


            }
            else
            {
                //Editing an existing Field
                var allFields = await _fieldMasterManager.GetFieldByIdAsync(input.Id.Value);

                 output = new CreateOrUpdateFieldInputMapTo
                {

                    input = new CreateOrUpdateFieldInput
                    {
                        Id = allFields.Id,
                        FieldName = allFields.Name,
                        FieldType = allFields.Type,
                        Status = allFields.Status ? "true" : "false",
                       
                    },
                  
                 };

            }

            return output;
        }
    }

}
