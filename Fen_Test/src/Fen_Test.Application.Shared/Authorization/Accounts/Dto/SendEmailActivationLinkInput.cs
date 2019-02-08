using System.ComponentModel.DataAnnotations;

namespace Fen_Test.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}