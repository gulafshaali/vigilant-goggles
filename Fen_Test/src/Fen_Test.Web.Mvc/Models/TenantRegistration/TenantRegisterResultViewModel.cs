using Abp.AutoMapper;
using Fen_Test.MultiTenancy.Dto;

namespace Fen_Test.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}