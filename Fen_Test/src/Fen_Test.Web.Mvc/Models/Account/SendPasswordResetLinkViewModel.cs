using System.ComponentModel.DataAnnotations;

namespace Fen_Test.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}