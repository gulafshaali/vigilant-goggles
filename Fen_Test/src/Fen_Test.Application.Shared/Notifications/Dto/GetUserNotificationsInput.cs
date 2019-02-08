using Abp.Notifications;
using Fen_Test.Dto;

namespace Fen_Test.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}