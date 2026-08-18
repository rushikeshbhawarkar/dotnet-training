using HospitalAPI.DTOs;

namespace HospitalAPI.Services
{
    public interface IAuthService
    {
        string? Login(LoginDto loginDto);
    }
}