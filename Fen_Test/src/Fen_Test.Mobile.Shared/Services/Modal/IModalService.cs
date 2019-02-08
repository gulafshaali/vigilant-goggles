using System.Threading.Tasks;
using Fen_Test.Views;
using Xamarin.Forms;

namespace Fen_Test.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
