using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.MessageDto;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Messages/MessageList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<MessageListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);

            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }
        public async Task<IActionResult> MessageDetails(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync($"Messages/GetByIdMessage/?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<MessageListDto>();
                    return View(values);
                }
                return View(response.StatusCode);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }
        public async Task<IActionResult> MessageDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var responsemessage = await client.DeleteAsync($"Messages/{id}");

                if (responsemessage.IsSuccessStatusCode)
                    return RedirectToAction("MessageList");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GenerateAiReply(int messageId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync($"Messages/GenerateMessageWithAI/{messageId}");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadAsStringAsync();
                    return Content(values!);
                }
                return View(response.StatusCode);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageMail(SendMailViewModel model)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsJsonAsync($"Messages/SendMessageMail", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("MessageList");
                }
                return View(response.StatusCode);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }
    }
}