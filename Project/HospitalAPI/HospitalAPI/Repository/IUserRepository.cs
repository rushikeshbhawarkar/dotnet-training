using HospitalAPI.Model;

namespace HospitalAPI.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}