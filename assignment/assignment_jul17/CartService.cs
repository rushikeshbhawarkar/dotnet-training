using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class CartService
    {
        private readonly Dictionary<int, Cart> _carts = new(); // keyed by CustomerId
        private readonly ProductService _productService;

        // A few sample coupons available in the system
        private readonly List<Coupon> _coupons = new()
        {
            new Coupon("SAVE10", 10m),
            new Coupon("SAVE20", 20m),
            new Coupon("WELCOME5", 5m)
        };

        public CartService(ProductService productService)
        {
            _productService = productService;
        }

        public Cart GetCart(int customerId)
        {
            if (!_carts.TryGetValue(customerId, out var cart))
            {
                cart = new Cart(customerId);
                _carts[customerId] = cart;
            }
            return cart;
        }

        public (bool Success, string Message) AddToCart(int customerId, int productId, int quantity)
        {
            if (quantity <= 0)
                return (false, "Quantity must be greater than zero.");

            var product = _productService.GetById(productId);
            if (product == null)
                return (false, $"Product with ID {productId} not found.");

            if (product.Quantity < quantity)
                return (false, $"Only {product.Quantity} unit(s) of {product.Name} in stock.");

            GetCart(customerId).AddItem(product, quantity);
            return (true, $"{product.Name} added to cart.");
        }

        public (bool Success, string Message) RemoveItem(int customerId, int productId)
        {
            var removed = GetCart(customerId).RemoveItem(productId);
            return removed ? (true, "Item removed from cart.") : (false, "Item not found in cart.");
        }

        public (bool Success, string Message) UpdateQuantity(int customerId, int productId, int quantity)
        {
            if (quantity <= 0)
                return (false, "Quantity must be greater than zero. Use Remove Item to delete it instead.");

            var product = _productService.GetById(productId);
            if (product != null && product.Quantity < quantity)
                return (false, $"Only {product.Quantity} unit(s) of {product.Name} in stock.");

            var updated = GetCart(customerId).UpdateQuantity(productId, quantity);
            return updated ? (true, "Quantity updated.") : (false, "Item not found in cart.");
        }

        public void ClearCart(int customerId) => GetCart(customerId).Clear();

        public (bool Success, string Message) ApplyCoupon(int customerId, string code)
        {
            var coupon = _coupons.FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
            if (coupon == null)
                return (false, "Invalid coupon code.");

            var cart = GetCart(customerId);
            if (cart.Items.Count == 0)
                return (false, "Cannot apply a coupon to an empty cart.");

            cart.AppliedCouponCode = coupon.Code;
            cart.CouponDiscountPercent = coupon.DiscountPercent;
            return (true, $"Coupon '{coupon.Code}' applied: {coupon.DiscountPercent}% off.");
        }
    }
}
