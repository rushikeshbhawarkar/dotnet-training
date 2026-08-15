namespace assignment_aug_13
{
    public class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

/*
Apply JWT Auth on Login(Customer or Admin) with rest api in EF
Customer – can register, login, view product
Admin – can add, update, delete products 

Entity with validation 
Customer (Id, Name, Email, Password, Role)
Product (ID, Name, Description, Price, Stock)
 */