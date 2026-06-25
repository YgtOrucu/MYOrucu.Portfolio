using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SendMessageSectionDto;
using System.Text.Json;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [AllowAnonymous]
    public class MuhsinYigitOrucuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MuhsinYigitOrucuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            if (TempData["RegisterErrors"] != null)
            {
                var errorsJson = TempData["RegisterErrors"]?.ToString();

                var errors = JsonSerializer.Deserialize<List<string>>(errorsJson!);

                ViewBag.RegisterErrors = errors;
            }

            if (TempData["LoginError"] != null)
            {
                var error = TempData["LoginError"]?.ToString();
                ViewBag.LoginErrors = error;
            }

            if (TempData["SendMessageError"] != null)
            {
                var errorsJson = TempData["SendMessageError"]?.ToString();
                var errors = JsonSerializer.Deserialize<List<string>>(errorsJson!);
                ViewBag.SendMessageError = errors;
            }

            if (TempData["SendMessageSuccess"] != null)
            {
                var success = TempData["SendMessageSuccess"]?.ToString();
                ViewBag.SendMessageSuccess = success;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDto dto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsJsonAsync("Messages/MessageCreate", dto);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SendMessageSuccess"] = "Mesajınız başarıyla gönderildi.En kısa zaman da sizinle iletişime geçeceğim";
                    return RedirectToAction("Index");
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    try
                    {
                        var errorMessage = await response.Content.ReadFromJsonAsync<List<string>>();
                        if (errorMessage != null && errorMessage.Any())
                        {
                            TempData["SendMessageError"] = JsonSerializer.Serialize(errorMessage);
                        }
                        else
                        {
                            TempData["SendMessageError"] = JsonSerializer.Serialize(new List<string> { "Bilinmeyen bir hata oluştu." });
                        }
                    }
                    catch
                    {
                        var rawMessage = await response.Content.ReadAsStringAsync();
                        TempData["SendMessageError"] = JsonSerializer.Serialize(new List<string> { !string.IsNullOrEmpty(rawMessage) ? rawMessage : "Sunucu hatası alındı." });
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["SendMessageError"] = JsonSerializer.Serialize(new List<string> { ex.Message });
                return RedirectToAction("Index");
            }
        }
    }
}
