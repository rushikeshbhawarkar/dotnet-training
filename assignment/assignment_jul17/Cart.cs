namespace ShopEaseApp.Models
{
    public class Cart
    {
        public int CustomerId { get; }
        public List<CartItem> Items { get; } = new();
        public string? AppliedCouponCode { get; set; }
        public decimal CouponDiscountPercent { get; set; } = 0;

        public const decimal GstRate = 0.18m; // 18% GST

        public Cart(int customerId)
        {
            CustomerId = customerId;
        }

        public void AddItem(Models.Product product, int quantity)
        {
            var existing = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (existing != null)
                existing.Quantity += quantity;
            else
                Items.Add(new CartItem(product, quantity));
        }

        public bool RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.ProductId == productId);
            if (item == null) return false;
            Items.Remove(item);
            return true;
        }

        public bool UpdateQuantity(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Product.ProductId == productId);
            if (item == null) return false;
            item.Quantity = quantity;
            return true;
        }

        public void Clear()
        {
            Items.Clear();
            AppliedCouponCode = null;
            CouponDiscountPercent = 0;
        }

        public decimal Subtotal => Items.Sum(i => i.Subtotal);

        public decimal CouponDiscountAmount => Math.Round(Subtotal * (CouponDiscountPercent / 100m), 2);

        public decimal TaxableAmount => Subtotal - CouponDiscountAmount;

        public decimal Gst => Math.Round(TaxableAmount * GstRate, 2);

        public decimal GrandTotal => TaxableAmount + Gst;
    }
}
