using System.ComponentModel.DataAnnotations;

namespace Fen_Test.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}