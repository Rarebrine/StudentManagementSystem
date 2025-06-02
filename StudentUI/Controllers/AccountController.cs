using Microsoft.AspNetCore.Mvc;
using StudentUI.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _http;

        public AccountController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("AuthService");
        }

        public IActionResult Login() => View();

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", model);
            var raw = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Invalid username or password.";
                return RedirectToAction("Login");
            }

            var result = JsonSerializer.Deserialize<AuthResponse>(raw);
            if (string.IsNullOrEmpty(result?.Token))
            {
                TempData["Error"] = "Invalid username or password.";
                return RedirectToAction("Login");
            }

            HttpContext.Session.SetString("JWT", result.Token);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", model);
            var raw = await response.Content.ReadAsStringAsync();
            Console.WriteLine("🔍 AuthService response: " + raw);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Registration failed: " + raw;
                return View(model);
            }

            AuthResponse? result = null;
            try
            {
                result = JsonSerializer.Deserialize<AuthResponse>(raw);
            }
            catch (JsonException)
            {
                ViewBag.Error = "Registration failed: response could not be parsed.";
                return View(model);
            }

            if (result?.Token is null)
            {
                ViewBag.Error = "Registration failed: token not returned.";
                return View(model);
            }

            HttpContext.Session.SetString("JWT", result.Token);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWT");
            return RedirectToAction("Login");
        }
    }

    public class AuthResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
    }
}
