namespace ShopEaseApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public string ShippingAddress { get; set; }

        public decimal Total { get; set; }       // subtotal before coupon/GST
        public decimal Discount { get; set; }     // coupon discount amount
        public decimal Gst { get; set; }
        public decimal GrandTotal { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus Status { get; set; }

        public int TotalQuantity => Items.Sum(i => i.Quantity);

        public Order(int orderId, int customerId, string customerName, List<OrderItem> items, string shippingAddress,
                      decimal total, decimal discount, decimal gst, decimal grandTotal,
                      PaymentMethod paymentMethod, PaymentStatus paymentStatus, OrderStatus status)
        {
            OrderId = orderId;
            Date = DateTime.Now;
            CustomerId = customerId;
            CustomerName = customerName;
            Items = items;
            ShippingAddress = shippingAddress;
            Total = total;
            Discount = discount;
            Gst = gst;
            GrandTotal = grandTotal;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            Status = status;
        }

        public override string ToString()
        {
            return $"Order #{OrderId} | {Date:dd-MMM-yyyy HH:mm} | {CustomerName} | " +
                   $"Items: {Items.Count} | Qty: {TotalQuantity} | GrandTotal: Rs.{GrandTotal:0.00} | " +
                   $"Payment: {PaymentMethod} ({PaymentStatus}) | Status: {Status}";
        }
    }
}
