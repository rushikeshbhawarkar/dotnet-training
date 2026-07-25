using ShopEaseApp.Models;

namespace ShopEaseApp.Services
{
    public class AuthService
    {
        private readonly List<Customer> _customers = new();
        private readonly Admin _admin;

        public Customer? CurrentCustomer { get; private set; }
        public Admin? CurrentAdmin { get; private set; }

        public bool IsLoggedIn => CurrentCustomer != null || CurrentAdmin != null;

        public AuthService()
        {
            // Default admin account, as required by the spec
            _admin = new Admin("admin", "admin123");
        }

        // ---------------- Customer Registration ----------------
        public (bool Success, string Message) Register(string username, string password, string fullName,
                                                         string email, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return (false, "Username and password cannot be empty.");

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                return (false, "This username is reserved.");

            if (_customers.Any(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return (false, "Username already exists.");

            if (_customers.Any(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return (false, "An account with this email already exists.");

            var customer = new Customer(username, password, fullName, email, phone, address);
            _customers.Add(customer);
            return (true, $"Registration successful. Your Customer ID is {customer.CustomerId}.");
        }

        // ---------------- Customer Login ----------------
        public (bool Success, string Message) LoginCustomer(string username, string password)
        {
            var customer = _customers.FirstOrDefault(c => c.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (customer == null || !customer.VerifyPassword(password))
                return (false, "Invalid username or password.");

            CurrentCustomer = customer;
            return (true, $"Welcome back, {customer.FullName}!");
        }

        // ---------------- Admin Login ----------------
        public (bool Success, string Message) LoginAdmin(string username, string password)
        {
            if (!_admin.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || !_admin.VerifyPassword(password))
                return (false, "Invalid admin credentials.");

            CurrentAdmin = _admin;
            return (true, "Admin login successful.");
        }

        // ---------------- Logout ----------------
        public void Logout()
        {
            CurrentCustomer = null;
            CurrentAdmin = null;
        }

        // ---------------- Update Profile ----------------
        public (bool Success, string Message) UpdateProfile(string fullName, string email, string phone, string address)
        {
            if (CurrentCustomer == null)
                return (false, "No customer is currently logged in.");

            CurrentCustomer.UpdateProfile(fullName, email, phone, address);
            return (true, "Profile updated successfully.");
        }

        // ---------------- Change Password ----------------
        public (bool Success, string Message) ChangePassword(string oldPassword, string newPassword)
        {
            User? current = CurrentCustomer as User ?? CurrentAdmin;
            if (current == null)
                return (false, "No user is currently logged in.");

            if (!current.VerifyPassword(oldPassword))
                return (false, "Old password is incorrect.");

            if (string.IsNullOrWhiteSpace(newPassword))
                return (false, "New password cannot be empty.");

            current.ChangePassword(newPassword);
            return (true, "Password changed successfully.");
        }
    }
}
