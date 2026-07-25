namespace ShopEaseApp.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        UPI,
        CashOnDelivery
    }

    public enum PaymentStatus
    {
        Success,
        Failed,
        Pending
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Delivered,
        Cancelled
    }
}
