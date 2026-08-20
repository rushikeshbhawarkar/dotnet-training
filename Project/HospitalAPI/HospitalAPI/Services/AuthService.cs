using HospitalAPI.DTOs;
using HospitalAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository repository,
            IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public string? Login(LoginDto loginDto)
        {
            if (loginDto.Username == null ||
                loginDto.Password == null)
            {
                return null;
            }

            var user = _repository
                .GetByUsername(loginDto.Username);

            if (user == null)
            {
                return null;
            }

            if (user.Password != loginDto.Password)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Name,
                    user.Username!
                ),

                new Claim(
                    ClaimTypes.Role,
                    user.Role!
                ),

                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()
                )
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}