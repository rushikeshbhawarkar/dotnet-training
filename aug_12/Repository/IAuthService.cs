namespace aug_12.Repository
{
    public interface IAuthService
    {
        string? Login(string username, string password);
    }
}
