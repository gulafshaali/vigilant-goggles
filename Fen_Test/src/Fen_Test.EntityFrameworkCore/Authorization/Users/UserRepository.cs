using Abp.Data;
using Abp.EntityFrameworkCore;
using Abp.UI;
using Fen_Test.Authorization.Users.Dto;
using Fen_Test.EntityFrameworkCore;
using Fen_Test.EntityFrameworkCore.Repositories;
using Fen_Test.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Fen_Test.Authorization.Users
{
    public  class UserRepository: Fen_TestRepositoryBase<Tenant>,IUserRepository
    //public class UserRepository :  IUserRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;


        public UserRepository(IDbContextProvider<Fen_TestDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
               : base(dbContextProvider)        
        {
            _transactionProvider = transactionProvider;
        }

      
        public async Task<List<GetFieldsFromServer>> GetUserNames(int pageNumber, int pageSize)
        {
            EnsureConnectionOpen();


            //using (var command = CreateCommand("GetUsernames", CommandType.StoredProcedure))   
            using (var command = CreateCommand("GetFields", CommandType.StoredProcedure, new SqlParameter("@PageNumber", pageNumber), new SqlParameter("@PageSize", pageSize)))
            // using (var command = CreateCommand("SELECT DisplayName FROM dbo.AbpRoles ", CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    //var result = new List<string>();
                    var result = new List<GetFieldsFromServer>();


                    while (dataReader.Read())
                    {
                        // result.Add(dataReader["DisplayName"].ToString());
                        result.Add(new GetFieldsFromServer() {  Status = Convert.ToBoolean(dataReader["Status"].ToString()), FieldType = dataReader["Type"].ToString()=="1" ? "Text Box" : "Text Area", Id = (long)dataReader["Id"], FieldName = dataReader["Name"].ToString() });

                    }


                    return result;
                }
            }
        }
        public async Task<List<GetPagesFromServer>> GetPagesData(int pageNumber, int pageSize)
        {
            EnsureConnectionOpen();


            //using (var command = CreateCommand("GetUsernames", CommandType.StoredProcedure))   
            using (var command = CreateCommand("GetPages", CommandType.StoredProcedure))
            // using (var command = CreateCommand("SELECT DisplayName FROM dbo.AbpRoles ", CommandType.Text))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    //var result = new List<string>();
                    var result = new List<GetPagesFromServer>();


                    while (dataReader.Read())
                    {
                        // result.Add(dataReader["DisplayName"].ToString());
                        result.Add(new GetPagesFromServer() { Status = Convert.ToBoolean(dataReader["PageStatus"].ToString()), PageName = dataReader["PageName"].ToString(), Id = (long)dataReader["Id"] });

                    }


                    return result;
                }
            }
        }
        public async Task<string> GetFormsAndFieldsData(int PageId)
        {
            EnsureConnectionOpen();

            try
            {

                using (var command = CreateCommand("GetFormsAndFields", CommandType.StoredProcedure, new SqlParameter("@PageId", PageId)))
                //  using (var command = CreateCommand("SELECT DisplayName FROM dbo.AbpRoles ", CommandType.Text))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {
                        string jsondata = string.Empty;
                        var result = new List<GetPagesFromServer>();


                        while (dataReader.Read())
                        {
                            
                            jsondata=dataReader[0].ToString();

                            //result.Add(new GetPagesFromServer() { Status = Convert.ToBoolean(dataReader["PageStatus"].ToString()), PageName = dataReader["PageName"].ToString(), Id = (long)dataReader["Id"] });

                        }


                        return jsondata;
                    }
                }
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        public async Task<string> GetFieldsDataFromPageAndFormId(long formId,long PageId)
        {
            EnsureConnectionOpen();

            try
            {

                using (var command = CreateCommand("GetFieldsByFormAndPageIds", CommandType.StoredProcedure, new SqlParameter("@FormId", formId),new SqlParameter("@PageId", PageId)))
                //  using (var command = CreateCommand("SELECT DisplayName FROM dbo.AbpRoles ", CommandType.Text))
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {
                        string jsondata = string.Empty;
                        var result = new List<GetFieldsFromServer>();


                        while (dataReader.Read())
                        {

                            jsondata = dataReader[0].ToString();

                            //result.Add(new GetPagesFromServer() { Status = Convert.ToBoolean(dataReader["PageStatus"].ToString()), PageName = dataReader["PageName"].ToString(), Id = (long)dataReader["Id"] });

                        }


                        return jsondata;
                    }
                }
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();


            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }


            return command;
        }

       

        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();


            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
    {
        {"ContextType", typeof(Fen_TestDbContext) },
        {"MultiTenancySide", MultiTenancySide }
    });
        }

    }
}
