using aug_14.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aug_14.Controllers
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

        // POST: api/Auth/login
        [HttpPost("login")]
        public IActionResult Login(string username,string password)
        {

            var token = _authService.Login(username,password);

            if (token == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new { token });
        }
    }


}