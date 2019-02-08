namespace Fen_Test.MultiTenancy.Payments
{
    public interface IPaymentGatewayPaymentStatusConverter
    {
        SubscriptionPaymentStatus ConvertToSubscriptionPaymentStatus(string externalStatus);
    }
}