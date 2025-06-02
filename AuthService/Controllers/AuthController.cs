using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var token = await _auth.Register(request);

            if (string.IsNullOrEmpty(token) || token == "User already exists." || token == "Token generation failed")
            {
                return BadRequest(new { error = token });
            }

            return Ok(new { token });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _auth.Login(request);

            if (token == "Invalid credentials.")
                return Unauthorized(new { error = token });

            return Ok(new { token });
        }
    }
}
