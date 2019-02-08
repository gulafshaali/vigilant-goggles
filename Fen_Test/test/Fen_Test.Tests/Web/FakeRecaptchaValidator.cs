using System.Threading.Tasks;
using Fen_Test.Security.Recaptcha;

namespace Fen_Test.Tests.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
