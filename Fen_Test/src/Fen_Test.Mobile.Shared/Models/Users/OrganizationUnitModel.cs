using Abp.AutoMapper;
using Fen_Test.Organizations.Dto;

namespace Fen_Test.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}