using Newtonsoft.Json;

namespace Fen_Test.MultiTenancy.Payments.Paypal
{
    public class PayPalTransaction
    {
        [JsonProperty("amount")]
        public PayPalAmount Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}