using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.FormsMaster
{
    public interface IFormManager : IDomainService
    {
        Task<List<Forms>> GetFieldsListAsync(long pageId);
       
    }
    public class FormManager: Fen_TestDomainServiceBase, IFormManager
    {
        private readonly IRepository<Forms, long> _formRepository;
       
        public FormManager(IRepository<Forms, long> formRepository)
        {
            _formRepository = formRepository;

        }
        public async Task<List<Forms>> GetFieldsListAsync(long pageId)
        {
            return await _formRepository.GetAllListAsync();
        }
    }
}
