namespace ShopEaseApp.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // Uses the product's discounted final price
        public decimal Subtotal => Product.FinalPrice * Quantity;

        public override string ToString()
        {
            return $"{Product.Name} x{Quantity}  ->  Rs.{Subtotal:0.00}";
        }
    }
}
