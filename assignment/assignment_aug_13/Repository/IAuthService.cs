namespace assignment_aug_13
{
    public interface IAuthService
    {
        string? Register(Customer customer);
        string? Login(string username, string password);
    }
}