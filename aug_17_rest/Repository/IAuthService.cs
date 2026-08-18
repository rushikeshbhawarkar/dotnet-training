namespace aug_17_rest.Repository
{
    public interface IAuthService
    {
        string? Login(string username, string password);
    }
}
