using System.Collections.Generic;
using Fen_Test.Caching.Dto;

namespace Fen_Test.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}