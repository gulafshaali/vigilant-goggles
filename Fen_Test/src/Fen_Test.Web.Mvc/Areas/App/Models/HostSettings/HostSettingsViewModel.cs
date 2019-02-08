using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fen_Test.Configuration.Host.Dto;
using Fen_Test.Editions.Dto;

namespace Fen_Test.Web.Areas.App.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}