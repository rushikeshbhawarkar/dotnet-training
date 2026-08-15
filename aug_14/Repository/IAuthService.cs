namespace aug_14.Repository
{
    public interface IAuthService
    {
        string? Login(string username, string password);
    }
}
