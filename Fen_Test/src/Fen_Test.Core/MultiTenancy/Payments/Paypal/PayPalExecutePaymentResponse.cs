using Newtonsoft.Json;

namespace Fen_Test.MultiTenancy.Payments.Paypal
{
    public class PayPalExecutePaymentResponse: ExecutePaymentResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        public override string GetId()
        {
            return Id;
        }
    }
}