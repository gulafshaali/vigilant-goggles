using System.Threading.Tasks;
using Abp.Application.Services;
using Fen_Test.Sessions.Dto;

namespace Fen_Test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
