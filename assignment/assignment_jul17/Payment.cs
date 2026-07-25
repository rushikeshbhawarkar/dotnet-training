namespace ShopEaseApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public Payment(int paymentId, int orderId, PaymentMethod method, PaymentStatus status, decimal amount)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Method = method;
            Status = status;
            Amount = amount;
            Timestamp = DateTime.Now;
        }

        public override string ToString() =>
            $"Payment #{PaymentId} | Order #{OrderId} | {Method} | Rs.{Amount:0.00} | Status: {Status}";
    }
}
