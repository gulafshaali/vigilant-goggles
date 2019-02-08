using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.FieldsMaster
{
    public interface IFieldMasterManager: IDomainService
    {
        Task CreateFieldsAsync(FieldMaster input);
        Task <FieldMaster> GetFieldsAsync(FieldMaster input);
        Task<FieldMaster> GetFieldByIdAsync(long input);
        Task<List<FieldMaster>> GetFieldsListAsync();
        Task UpdateFieldStatus(FieldMaster input);
    }
    public class FieldMasterManager: Fen_TestDomainServiceBase, IFieldMasterManager
    {
        private readonly IRepository<FieldMaster, long> _fieldsRepository;
        public FieldMasterManager(IRepository<FieldMaster, long> fieldsRepository) {
            _fieldsRepository = fieldsRepository;

        }
        public async Task CreateFieldsAsync(FieldMaster input)
        {
            await _fieldsRepository.InsertAsync(input);
        }
        public async Task<FieldMaster> GetFieldsAsync(FieldMaster input)
        {
            return await _fieldsRepository.FirstOrDefaultAsync(e => e.Name.ToUpper() == input.Name.ToUpper() && e.Type == input.Type && e.IsDeleted==false);
        }
        public async Task<List<FieldMaster>> GetFieldsListAsync()
        {
            return await _fieldsRepository.GetAllListAsync();
        }
        public async Task UpdateFieldStatus(FieldMaster input)
        {
            await _fieldsRepository.UpdateAsync(input);
        }
        public async Task<FieldMaster> GetFieldByIdAsync(long Id)
        {
            return  await _fieldsRepository.FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
