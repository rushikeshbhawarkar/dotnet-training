using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var token = _service.Login(loginDto);

            if (token == null)
            {
                return Unauthorized(
                    "Invalid username or password."
                );
            }

            return Ok(new
            {
                Token = token
            });
        }
    }
}