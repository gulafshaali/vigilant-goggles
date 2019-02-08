using Abp.AutoMapper;
using Fen_Test.Editions;
using Fen_Test.MultiTenancy.Payments.Dto;

namespace Fen_Test.Web.Areas.App.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}