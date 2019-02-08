using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Fen_Test.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel
    {
        public List<ComboboxItemDto> Permissions { get; set; }
    }
}