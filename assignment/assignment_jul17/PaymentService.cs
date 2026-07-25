using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class PaymentService
    {
        private readonly List<Payment> _payments = new();
        private int _nextPaymentId = 1;
        private readonly Random _random = new();

        // Simulates a payment gateway call. Cash on Delivery is always Pending until delivery.
        // Card/UPI payments succeed most of the time, with a small simulated failure chance.
        public Payment ProcessPayment(int orderId, PaymentMethod method, decimal amount)
        {
            PaymentStatus status;

            if (method == PaymentMethod.CashOnDelivery)
            {
                status = PaymentStatus.Pending;
            }
            else
            {
                // ~90% success rate simulation
                status = _random.Next(1, 101) <= 90 ? PaymentStatus.Success : PaymentStatus.Failed;
            }

            var payment = new Payment(_nextPaymentId++, orderId, method, status, amount);
            _payments.Add(payment);
            return payment;
        }

        public List<Payment> GetPaymentsForOrder(int orderId) =>
            _payments.Where(p => p.OrderId == orderId).ToList();
    }
}
