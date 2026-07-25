using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders = new();
        private int _nextOrderId = 5001;

        private readonly CartService _cartService;
        private readonly ProductService _productService;
        private readonly PaymentService _paymentService;

        public OrderService(CartService cartService, ProductService productService, PaymentService paymentService)
        {
            _cartService = cartService;
            _productService = productService;
            _paymentService = paymentService;
        }

        // ---------------- Checkout (returns the cart summary to review before placing) ----------------
        public Cart Checkout(int customerId) => _cartService.GetCart(customerId);

        // ---------------- Place Order (confirm address + select payment happen in the caller/UI) ----------------
        public (bool Success, string Message, Order? Order) PlaceOrder(
            int customerId, string customerName, string shippingAddress, PaymentMethod paymentMethod)
        {
            var cart = _cartService.GetCart(customerId);

            if (cart.Items.Count == 0)
                return (false, "Your cart is empty.", null);

            if (string.IsNullOrWhiteSpace(shippingAddress))
                return (false, "Shipping address is required.", null);

            // Verify stock is still available for every item
            foreach (var item in cart.Items)
            {
                var product = _productService.GetById(item.Product.ProductId);
                if (product == null || product.Quantity < item.Quantity)
                    return (false, $"Insufficient stock for {item.Product.Name}.", null);
            }

            var orderItems = cart.Items
                .Select(i => new OrderItem(i.Product.ProductId, i.Product.Name, i.Product.FinalPrice, i.Quantity))
                .ToList();

            decimal total = cart.Subtotal;
            decimal discount = cart.CouponDiscountAmount;
            decimal gst = cart.Gst;
            decimal grandTotal = cart.GrandTotal;

            // Simulate payment
            var payment = _paymentService.ProcessPayment(_nextOrderId, paymentMethod, grandTotal);

            OrderStatus status = payment.Status switch
            {
                PaymentStatus.Success => OrderStatus.Confirmed,
                PaymentStatus.Pending => OrderStatus.Confirmed,  // e.g. Cash on Delivery
                PaymentStatus.Failed => OrderStatus.Cancelled,
                _ => OrderStatus.Pending
            };

            var order = new Order(_nextOrderId++, customerId, customerName, orderItems, shippingAddress,
                                   total, discount, gst, grandTotal, paymentMethod, payment.Status, status);
            _orders.Add(order);

            if (payment.Status == PaymentStatus.Failed)
                return (false, "Payment failed. Your order was not placed. Please try again.", order);

            // Deduct stock and clear the cart only on a successful/pending (COD) order
            foreach (var item in cart.Items)
            {
                var product = _productService.GetById(item.Product.ProductId);
                if (product != null)
                    product.Quantity -= item.Quantity;
            }
            cart.Clear();

            return (true, $"Order placed successfully! Order ID: {order.OrderId}", order);
        }

        // ---------------- Order History ----------------
        public List<Order> GetOrderHistory(int customerId) =>
            _orders.Where(o => o.CustomerId == customerId).OrderByDescending(o => o.Date).ToList();

        public List<Order> SearchOrder(int customerId, string keyword)
        {
            var history = GetOrderHistory(customerId);
            if (string.IsNullOrWhiteSpace(keyword)) return new List<Order>();

            return history.Where(o =>
                o.OrderId.ToString() == keyword ||
                o.Status.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                o.Items.Any(i => i.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public Order? GetOrderById(int customerId, int orderId) =>
            _orders.FirstOrDefault(o => o.CustomerId == customerId && o.OrderId == orderId);

        // ---------------- Cancel Order ----------------
        public (bool Success, string Message) CancelOrder(int customerId, int orderId)
        {
            var order = GetOrderById(customerId, orderId);
            if (order == null)
                return (false, $"Order #{orderId} not found.");

            if (order.Status is OrderStatus.Delivered or OrderStatus.Cancelled)
                return (false, $"Order #{orderId} cannot be cancelled (current status: {order.Status}).");

            // Restock items
            foreach (var item in order.Items)
            {
                var product = _productService.GetById(item.ProductId);
                if (product != null)
                    product.Quantity += item.Quantity;
            }

            order.Status = OrderStatus.Cancelled;
            return (true, $"Order #{orderId} has been cancelled.");
        }
    }
}
