using AuthService.Data;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AuthDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> Register(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
                return "User already exists.";

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = hash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateToken(user);

            Console.WriteLine("Generated token: " + token);

            return token ?? "Token generation failed";
        }

        public async Task<string> Login(LoginRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return "Invalid credentials.";

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];

            if (string.IsNullOrEmpty(key) || key.Length < 32)
            {
                Console.WriteLine("JWT Key is invalid or too short.");
                return null!;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            Console.WriteLine("Generated JWT: " + jwt);

            return jwt;
        }

    }
}
