using System.Collections.Generic;
using Fen_Test.Editions.Dto;

namespace Fen_Test.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}