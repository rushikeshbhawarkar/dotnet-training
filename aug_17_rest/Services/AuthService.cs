using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace aug_17_rest.Services
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
            // Find user
            var user = context.Users12.FirstOrDefault(u => u.UserName == username && u.Password == password);

            // Invalid username/password
            if (user == null)
                return null;

            // Create claims - creation of jwt
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // adds a claim containing the unique user ID
            new Claim(ClaimTypes.Name, user.UserName),               // adds a claim containing username
            new Claim(ClaimTypes.Role, user.Role)                    // adds a claim containing user's assigned security role
        };

            // Get JWT Key
            // Retrieves a secret string from application, converts it into byte array & builds security key used for signing
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
