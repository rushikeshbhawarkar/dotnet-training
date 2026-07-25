namespace ShopEaseApp.Models
{
    // Abstract base class - demonstrates abstraction & inheritance.
    // Both Customer and Admin derive from this.
    public abstract class User
    {
        public string Username { get; set; }
        protected string Password { get; set; } // protected: only accessible to derived classes

        protected User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public virtual void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        // Every derived user type must describe its own role
        public abstract string GetRole();
    }
}
