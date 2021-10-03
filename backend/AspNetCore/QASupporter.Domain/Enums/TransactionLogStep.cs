namespace QASupporter.Domain.Enums
{
    public enum TransactionLogStep
    {
        AddUserPaymentInfo = 1,
        StripeSetupIntentCreate = 2,
        StripeCreatePaymentIntent = 3,
        StripCapture = 4,
        StripeCancel = 5,
        StripeRefundCreate = 6,
        GetOrderInfo = 7,
        CustomExceptionHandlerMiddleware = 8,
        StripeWebhookDataReceived = 9,
        StripeWebhookUpdateTransactionStatus = 10,
        DoPaymentInstore = 11,
        BaseApiControllerExceptionHandling = 12,
        PreGenerateResizedImage = 13,
        GetResizedImage = 14,
        ResizeImage = 15
    }
}
