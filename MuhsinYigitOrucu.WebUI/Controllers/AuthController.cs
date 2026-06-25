using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.AuthsDtos;
using System.Security.Claims;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient("PortfolioClient");
            var responsebody = await client.PostAsJsonAsync("Auths/Login", dto);

            if (!responsebody.IsSuccessStatusCode)
            {
                var errorResponse = await responsebody.Content.ReadFromJsonAsync<ApiErrorDto>();
                TempData["LoginError"] = errorResponse?.Message;
                return RedirectToAction("Index", "MuhsinYigitOrucu");
            }

            var user = await responsebody.Content.ReadFromJsonAsync<LoginResponseDto>();

            if (user.Role == "Admin")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim("FullName",user.NameSurname!),
                new Claim(ClaimTypes.Role,user.Role!)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = dto.RememberMe, ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "AdminDashboard");
            }

            return RedirectToAction("Index", "MuhsinYigitOrucu");
        }

        public async Task<IActionResult> Logout()
        {
            var client = _httpClientFactory.CreateClient("PortfolioClient");
            var response = await client.PostAsync("Auths/Logout", null);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "MuhsinYigitOrucu");

            }
            return View();
        }
    }
}
