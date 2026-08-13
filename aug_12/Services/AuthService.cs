using aug_12.Data;
using aug_12.Models;
using aug_12.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace aug_12.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string? Login(string username, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null)
            {
                return null;
            }
            // Create claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };
            // Get JWT Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            // credentails
            var credentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create jwt
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentails
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
