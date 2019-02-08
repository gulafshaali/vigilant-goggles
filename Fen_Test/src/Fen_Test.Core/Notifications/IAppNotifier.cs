using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using Fen_Test.Authorization.Users;
using Fen_Test.MultiTenancy;

namespace Fen_Test.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
