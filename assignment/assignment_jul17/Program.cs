using ShopEaseApp.Models;
using ShopEaseApp.Services;

namespace ShopEaseApp
{
    public class Program
    {
        private static readonly AuthService _authService = new();
        private static readonly ProductService _productService = new();
        private static readonly CategoryService _categoryService = new();
        private static readonly CartService _cartService = new(_productService);
        private static readonly PaymentService _paymentService = new();
        private static readonly OrderService _orderService = new(_cartService, _productService, _paymentService);
        private static readonly InvoiceService _invoiceService = new();

        public static void Main(string[] args)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   Welcome to ShopEase Console App");
            Console.WriteLine("=========================================");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- MAIN MENU ---");
                Console.WriteLine("1. Register (Customer)");
                Console.WriteLine("2. Login (Customer)");
                Console.WriteLine("3. Login (Admin)");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        if (LoginCustomer())
                            CustomerMenu();
                        break;
                    case "3":
                        if (LoginAdmin())
                            AdminMenu();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Thank you for using ShopEase. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // ===================== AUTH FLOWS =====================

        private static void RegisterCustomer()
        {
            Console.WriteLine("\n--- Customer Registration ---");
            Console.Write("Choose a username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Choose a password: ");
            string password = Console.ReadLine() ?? "";
            Console.Write("Full name: ");
            string fullName = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";
            Console.Write("Address: ");
            string address = Console.ReadLine() ?? "";

            var (success, message) = _authService.Register(username, password, fullName, email, phone, address);
            Console.WriteLine(message);
        }

        private static bool LoginCustomer()
        {
            Console.WriteLine("\n--- Customer Login ---");
            Console.Write("Username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            var (success, message) = _authService.LoginCustomer(username, password);
            Console.WriteLine(message);
            return success;
        }

        private static bool LoginAdmin()
        {
            Console.WriteLine("\n--- Admin Login ---");
            Console.Write("Username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine() ?? "";

            var (success, message) = _authService.LoginAdmin(username, password);
            Console.WriteLine(message);
            return success;
        }

        // ===================== CUSTOMER MENU =====================

        private static void CustomerMenu()
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine($"\n--- CUSTOMER MENU ({_authService.CurrentCustomer?.Username}) ---");
                Console.WriteLine("1. View Profile");
                Console.WriteLine("2. Update Profile");
                Console.WriteLine("3. Change Password");
                Console.WriteLine("4. View Products");
                Console.WriteLine("5. Shopping Cart");
                Console.WriteLine("6. Checkout / Place Order");
                Console.WriteLine("7. Order History");
                Console.WriteLine("8. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(_authService.CurrentCustomer);
                        break;
                    case "2":
                        UpdateProfile();
                        break;
                    case "3":
                        ChangePassword();
                        break;
                    case "4":
                        ViewAllProducts();
                        break;
                    case "5":
                        CartMenu();
                        break;
                    case "6":
                        PlaceOrderFlow();
                        break;
                    case "7":
                        OrderHistoryMenu();
                        break;
                    case "8":
                        _authService.Logout();
                        Console.WriteLine("Logged out successfully.");
                        logout = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private static void UpdateProfile()
        {
            Console.WriteLine("\n--- Update Profile ---");
            Console.Write("Full name: ");
            string fullName = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? "";
            Console.Write("Address: ");
            string address = Console.ReadLine() ?? "";

            var (success, message) = _authService.UpdateProfile(fullName, email, phone, address);
            Console.WriteLine(message);
        }

        private static void ChangePassword()
        {
            Console.WriteLine("\n--- Change Password ---");
            Console.Write("Old password: ");
            string oldPassword = Console.ReadLine() ?? "";
            Console.Write("New password: ");
            string newPassword = Console.ReadLine() ?? "";

            var (success, message) = _authService.ChangePassword(oldPassword, newPassword);
            Console.WriteLine(message);
        }

        // ===================== SHOPPING CART (Module 4) =====================

        private static void CartMenu()
        {
            int customerId = _authService.CurrentCustomer!.CustomerId;
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- SHOPPING CART ---");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Clear Cart");
                Console.WriteLine("5. View Cart / Total");
                Console.WriteLine("6. Apply Coupon");
                Console.WriteLine("7. Back");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewAllProducts();
                        int productId = ReadInt("Enter Product ID to add: ");
                        int qty = ReadInt("Quantity: ");
                        var (aSuccess, aMessage) = _cartService.AddToCart(customerId, productId, qty);
                        Console.WriteLine(aMessage);
                        break;
                    case "2":
                        int removeId = ReadInt("Enter Product ID to remove: ");
                        var (rSuccess, rMessage) = _cartService.RemoveItem(customerId, removeId);
                        Console.WriteLine(rMessage);
                        break;
                    case "3":
                        int updateId = ReadInt("Enter Product ID to update: ");
                        int newQty = ReadInt("New quantity: ");
                        var (uSuccess, uMessage) = _cartService.UpdateQuantity(customerId, updateId, newQty);
                        Console.WriteLine(uMessage);
                        break;
                    case "4":
                        _cartService.ClearCart(customerId);
                        Console.WriteLine("Cart cleared.");
                        break;
                    case "5":
                        PrintCart(customerId);
                        break;
                    case "6":
                        Console.Write("Enter coupon code: ");
                        string code = Console.ReadLine() ?? "";
                        var (cSuccess, cMessage) = _cartService.ApplyCoupon(customerId, code);
                        Console.WriteLine(cMessage);
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private static void PrintCart(int customerId)
        {
            var cart = _cartService.GetCart(customerId);
            if (cart.Items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("\n--- Cart Summary ---");
            foreach (var item in cart.Items)
                Console.WriteLine(item);

            Console.WriteLine("---------------------------");
            Console.WriteLine($"Subtotal        : Rs.{cart.Subtotal:0.00}");
            if (!string.IsNullOrEmpty(cart.AppliedCouponCode))
                Console.WriteLine($"Coupon ({cart.AppliedCouponCode}) : -Rs.{cart.CouponDiscountAmount:0.00}");
            Console.WriteLine($"GST (18%)       : Rs.{cart.Gst:0.00}");
            Console.WriteLine($"Grand Total     : Rs.{cart.GrandTotal:0.00}");
        }

        // ===================== ORDER MODULE (Module 5 & 6) =====================

        private static void PlaceOrderFlow()
        {
            int customerId = _authService.CurrentCustomer!.CustomerId;
            var cart = _orderService.Checkout(customerId);

            if (cart.Items.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Add products before checking out.");
                return;
            }

            Console.WriteLine("\n--- Checkout ---");
            PrintCart(customerId);

            Console.Write($"\nConfirm shipping address [{_authService.CurrentCustomer!.Address}]: ");
            string address = ReadOrDefault(_authService.CurrentCustomer!.Address);

            Console.WriteLine("\nSelect Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. UPI");
            Console.WriteLine("4. Cash on Delivery");
            Console.Write("Choice: ");

            PaymentMethod method = Console.ReadLine() switch
            {
                "1" => PaymentMethod.CreditCard,
                "2" => PaymentMethod.DebitCard,
                "3" => PaymentMethod.UPI,
                "4" => PaymentMethod.CashOnDelivery,
                _ => PaymentMethod.CashOnDelivery
            };

            var (success, message, order) = _orderService.PlaceOrder(
                customerId, _authService.CurrentCustomer!.FullName, address, method);

            Console.WriteLine(message);

            if (success && order != null)
            {
                Console.WriteLine(order);
                Console.Write("Download invoice now? (y/n): ");
                if ((Console.ReadLine() ?? "").Trim().ToLower() == "y")
                {
                    string path = _invoiceService.SaveInvoiceToFile(order);
                    Console.WriteLine($"Invoice saved to: {path}");
                }
            }
        }

        private static void OrderHistoryMenu()
        {
            int customerId = _authService.CurrentCustomer!.CustomerId;
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- ORDER HISTORY ---");
                Console.WriteLine("1. View Previous Orders");
                Console.WriteLine("2. Search Order");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Download Invoice");
                Console.WriteLine("5. Back");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        var orders = _orderService.GetOrderHistory(customerId);
                        if (orders.Count == 0)
                            Console.WriteLine("You have no past orders.");
                        else
                            foreach (var o in orders) Console.WriteLine(o);
                        break;
                    case "2":
                        Console.Write("Enter Order ID, status, or product name: ");
                        string keyword = Console.ReadLine() ?? "";
                        var results = _orderService.SearchOrder(customerId, keyword);
                        if (results.Count == 0)
                            Console.WriteLine("No matching orders found.");
                        else
                            foreach (var o in results) Console.WriteLine(o);
                        break;
                    case "3":
                        int cancelId = ReadInt("Enter Order ID to cancel: ");
                        var (success, message) = _orderService.CancelOrder(customerId, cancelId);
                        Console.WriteLine(message);
                        break;
                    case "4":
                        int invoiceId = ReadInt("Enter Order ID: ");
                        var order = _orderService.GetOrderById(customerId, invoiceId);
                        if (order == null)
                        {
                            Console.WriteLine("Order not found.");
                        }
                        else
                        {
                            string path = _invoiceService.SaveInvoiceToFile(order);
                            Console.WriteLine($"Invoice saved to: {path}");
                        }
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // ===================== ADMIN MENU =====================

        private static void AdminMenu()
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine("\n--- ADMIN MENU ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Search Product");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Category Management");
                Console.WriteLine("7. Logout");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        SearchProduct();
                        break;
                    case "5":
                        ViewAllProducts();
                        break;
                    case "6":
                        CategoryMenu();
                        break;
                    case "7":
                        _authService.Logout();
                        Console.WriteLine("Admin logged out successfully.");
                        logout = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // ===================== CATEGORY MENU (Module 3) =====================

        private static void CategoryMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- CATEGORY MANAGEMENT ---");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("4. View All Categories");
                Console.WriteLine("5. Back");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Category name: ");
                        string name = Console.ReadLine() ?? "";
                        var category = _categoryService.AddCategory(name);
                        Console.WriteLine($"Category added with ID {category.CategoryId}.");
                        break;
                    case "2":
                        int updateId = ReadInt("Enter Category ID to update: ");
                        Console.Write("New name: ");
                        string newName = Console.ReadLine() ?? "";
                        var (uSuccess, uMessage) = _categoryService.UpdateCategory(updateId, newName);
                        Console.WriteLine(uMessage);
                        break;
                    case "3":
                        int deleteId = ReadInt("Enter Category ID to delete: ");
                        var (dSuccess, dMessage) = _categoryService.DeleteCategory(deleteId);
                        Console.WriteLine(dMessage);
                        break;
                    case "4":
                        foreach (var c in _categoryService.GetAllCategories())
                            Console.WriteLine(c);
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.WriteLine("\n--- Add Product ---");
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Category: ");
            string category = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";
            decimal price = ReadDecimal("Price: ");
            int quantity = ReadInt("Quantity: ");
            Console.Write("Brand: ");
            string brand = Console.ReadLine() ?? "";
            decimal discount = ReadDecimal("Discount (%): ");
            double rating = ReadDouble("Rating (0-5): ");

            var product = _productService.AddProduct(name, category, description, price, quantity, brand, discount, rating);
            Console.WriteLine($"Product added successfully with ID {product.ProductId}.");
        }

        private static void UpdateProduct()
        {
            Console.WriteLine("\n--- Update Product ---");
            int id = ReadInt("Enter Product ID to update: ");
            var existing = _productService.GetById(id);
            if (existing == null)
            {
                Console.WriteLine($"Product with ID {id} not found.");
                return;
            }

            Console.WriteLine("Leave a field blank to keep the current value.");

            Console.Write($"Name [{existing.Name}]: ");
            string name = ReadOrDefault(existing.Name);

            Console.Write($"Category [{existing.Category}]: ");
            string category = ReadOrDefault(existing.Category);

            Console.Write($"Description [{existing.Description}]: ");
            string description = ReadOrDefault(existing.Description);

            Console.Write($"Price [{existing.Price}]: ");
            decimal price = ReadDecimalOrDefault(existing.Price);

            Console.Write($"Quantity [{existing.Quantity}]: ");
            int quantity = ReadIntOrDefault(existing.Quantity);

            Console.Write($"Brand [{existing.Brand}]: ");
            string brand = ReadOrDefault(existing.Brand);

            Console.Write($"Discount [{existing.Discount}]: ");
            decimal discount = ReadDecimalOrDefault(existing.Discount);

            Console.Write($"Rating [{existing.Rating}]: ");
            double rating = ReadDoubleOrDefault(existing.Rating);

            var (success, message) = _productService.UpdateProduct(id, name, category, description, price, quantity, brand, discount, rating);
            Console.WriteLine(message);
        }

        private static void DeleteProduct()
        {
            Console.WriteLine("\n--- Delete Product ---");
            int id = ReadInt("Enter Product ID to delete: ");
            var (success, message) = _productService.DeleteProduct(id);
            Console.WriteLine(message);
        }

        private static void SearchProduct()
        {
            Console.WriteLine("\n--- Search Product ---");
            Console.Write("Enter keyword (name, category, brand, or ID): ");
            string keyword = Console.ReadLine() ?? "";
            var results = _productService.SearchProduct(keyword);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching products found.");
                return;
            }

            foreach (var product in results)
                Console.WriteLine(product);
        }

        private static void ViewAllProducts()
        {
            Console.WriteLine("\n--- All Products ---");
            var products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var product in products)
                Console.WriteLine(product);
        }

        // ===================== INPUT HELPERS =====================

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Please enter a valid whole number.");
            }
        }

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Please enter a valid number.");
            }
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.WriteLine("Please enter a valid number.");
            }
        }

        private static string ReadOrDefault(string currentValue)
        {
            string input = Console.ReadLine() ?? "";
            return string.IsNullOrWhiteSpace(input) ? currentValue : input;
        }

        private static decimal ReadDecimalOrDefault(decimal currentValue)
        {
            string input = Console.ReadLine() ?? "";
            return decimal.TryParse(input, out decimal value) ? value : currentValue;
        }

        private static int ReadIntOrDefault(int currentValue)
        {
            string input = Console.ReadLine() ?? "";
            return int.TryParse(input, out int value) ? value : currentValue;
        }

        private static double ReadDoubleOrDefault(double currentValue)
        {
            string input = Console.ReadLine() ?? "";
            return double.TryParse(input, out double value) ? value : currentValue;
        }
    }
}
