using System.Threading.Tasks;
using Abp.Net.Mail;
using Fen_Test.Configuration.Host.Dto;

namespace Fen_Test.Configuration
{
    public abstract class SettingsAppServiceBase : Fen_TestAppServiceBase
    {
        private readonly IEmailSender _emailSender;

        protected SettingsAppServiceBase(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        #region Send Test Email

        public async Task SendTestEmail(SendTestEmailInput input)
        {
            await _emailSender.SendAsync(
                input.EmailAddress,
                L("TestEmail_Subject"),
                L("TestEmail_Body")
            );
        }

        #endregion
    }
}
