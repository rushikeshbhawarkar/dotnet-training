using assignment_aug_13.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace assignment_aug_13.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string? Register(Customer customer)
        {
            // Check if username already exists
            if (_context.Customer.Any(c => c.Username == customer.Username))
            {
                return null;
            }

            // Assign default role if none provided
            if (string.IsNullOrEmpty(customer.Role))
            {
                customer.Role = "Customer";
            }

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return GenerateJwtToken(customer);
        }

        public string? Login(string username, string password)
        {
            var customer = _context.Customer
                .FirstOrDefault(c => c.Username == username && c.Password == password);

            if (customer == null)
            {
                return null;
            }

            return GenerateJwtToken(customer);
        }

        private string GenerateJwtToken(Customer customer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Name, customer.Username),
                new Claim(ClaimTypes.Role, customer.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}