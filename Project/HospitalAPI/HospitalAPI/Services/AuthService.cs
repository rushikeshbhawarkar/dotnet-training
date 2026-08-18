using HospitalAPI.DTOs;
using HospitalAPI.Repositories;
using Microsoft.AspNetCore.Identity;

namespace HospitalAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<object> _passwordHasher;

        public AuthService(IUserRepository repository)
        {
            _repository = repository;
            _passwordHasher = new PasswordHasher<object>();
        }

        public string? Login(LoginDto loginDto)
        {
            var user = _repository.GetByUsername(loginDto.Username);

            if (user == null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(
                null!,
                user.PasswordHash,
                loginDto.Password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // JWT token generation will be added here

            return null;
        }
    }
}