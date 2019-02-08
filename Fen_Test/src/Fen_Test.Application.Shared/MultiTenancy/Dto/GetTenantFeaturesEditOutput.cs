using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fen_Test.Editions.Dto;

namespace Fen_Test.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}