using System.Threading.Tasks;
using Fen_Test.Sessions.Dto;

namespace Fen_Test.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
