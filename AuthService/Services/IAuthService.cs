using AuthService.Models;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequest request);
        Task<string> Login(LoginRequest request);
    }
}
