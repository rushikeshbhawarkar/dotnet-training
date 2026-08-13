using aug_12.Models;
using aug_12.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aug_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var token = service.Login(user.UserName, user.Password);

            if (token == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new { token = token });
        }
    }
}
