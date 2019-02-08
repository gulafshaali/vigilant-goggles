using System.ComponentModel.DataAnnotations;

namespace Fen_Test.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
