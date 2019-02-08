using System.Threading.Tasks;

namespace Fen_Test.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}