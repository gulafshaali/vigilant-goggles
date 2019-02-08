using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fen_Test.Editions.Dto;

namespace Fen_Test.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}