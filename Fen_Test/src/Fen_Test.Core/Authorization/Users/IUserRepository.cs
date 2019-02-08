using Abp.Domain.Repositories;
using Fen_Test.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.Authorization.Users
{
    //public interface IUserRepository: IRepository<User,long>
    public interface IUserRepository 
    {
        //Task<List<string>> GetUserNames();
        //Task<List<GetFieldsFromServer>> GetUserNames();
        Task<List<GetFieldsFromServer>> GetUserNames(int pageNumber, int pageSize);
        Task<List<GetPagesFromServer>> GetPagesData(int pageNumber, int pageSize);
        Task<string> GetFormsAndFieldsData(int PageId);
        Task<string> GetFieldsDataFromPageAndFormId(long formId, long pageId);
    }
}
