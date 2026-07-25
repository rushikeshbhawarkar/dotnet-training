namespace ShopEaseApp.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; } // final price per unit at time of order
        public int Quantity { get; set; }

        public OrderItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public decimal Subtotal => UnitPrice * Quantity;

        public override string ToString() => $"{ProductName} x{Quantity} @ Rs.{UnitPrice:0.00} = Rs.{Subtotal:0.00}";
    }
}
