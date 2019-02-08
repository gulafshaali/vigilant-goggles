using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fen_Test.Configuration.Tenants.Dto;

namespace Fen_Test.Web.Areas.App.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}