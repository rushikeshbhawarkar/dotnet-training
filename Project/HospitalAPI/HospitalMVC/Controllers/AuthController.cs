using aug_17_mvc.Models;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace aug_17_mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var client = _httpClientFactory.CreateClient("HospitalAPI");

            var response = await client.PostAsJsonAsync(
                "api/Auth/login",
                loginModel);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid username or password.";

                return View(loginModel);
            }

            var result = await response.Content
                .ReadFromJsonAsync<LoginResponse>();

            if (result == null || string.IsNullOrEmpty(result.Token))
            {
                ViewBag.Error = "Login failed.";

                return View(loginModel);
            }

            HttpContext.Session.SetString(
                "Token",
                result.Token);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

    public class LoginResponse
    {
        public string? Token { get; set; }
    }
}