using System.Collections.Generic;
using Abp.Localization;
using Fen_Test.Install.Dto;

namespace Fen_Test.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
