using assignment_aug_13.Data;
using assignment_aug_13.Services;
using Microsoft.AspNetCore.Mvc;

namespace assignment_aug_13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = _authService.Register(customer);
            if (token == null)
            {
                return BadRequest(new { message = "Username already exists." });
            }

            return Ok(new { token });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _authService.Login(loginDto.Username, loginDto.Password);
            if (token == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new { token });
        }
    }

    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}