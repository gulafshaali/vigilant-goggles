using Abp.AutoMapper;
using Fen_Test.MultiTenancy;
using Fen_Test.MultiTenancy.Dto;
using Fen_Test.Web.Areas.App.Models.Common;

namespace Fen_Test.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}