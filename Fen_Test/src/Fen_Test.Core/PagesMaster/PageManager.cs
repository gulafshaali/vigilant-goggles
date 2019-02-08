using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.PagesMaster
{
    public interface IPageManager : IDomainService
    {
        Task<List<PagesFormsAssociation>> GetFormsListByPageIdAsync(long pageId);

    }
    public class PageManager : Fen_TestDomainServiceBase, IPageManager    
    {

        private readonly IRepository<PagesFormsAssociation, long> _pageFormRepository;
        public PageManager(IRepository<PagesFormsAssociation, long> pageFormRepository)
        {
            _pageFormRepository = pageFormRepository;

        }
        public async Task<List<PagesFormsAssociation>> GetFormsListByPageIdAsync(long pageId)
        {
            return await _pageFormRepository.GetAllListAsync(e => e.PagesId== pageId);
        }
    }
}
