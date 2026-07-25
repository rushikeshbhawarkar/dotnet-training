namespace ShopEaseApp.Models
{
    public class Customer : User
    {
        private static int _nextId = 1;

        public int CustomerId { get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Customer(string username, string password, string fullName, string email, string phone, string address)
            : base(username, password)
        {
            CustomerId = _nextId++;
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public override string GetRole() => "Customer";

        public void UpdateProfile(string fullName, string email, string phone, string address)
        {
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return $"[{CustomerId}] {FullName} | Username: {Username} | Email: {Email} | Phone: {Phone} | Address: {Address}";
        }
    }
}
