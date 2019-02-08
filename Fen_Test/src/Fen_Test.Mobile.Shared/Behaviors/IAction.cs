using Xamarin.Forms.Internals;

namespace Fen_Test.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}