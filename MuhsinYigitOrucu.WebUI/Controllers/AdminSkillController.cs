using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.SkillsDto;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSkillController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSkillController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SkillList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Skills/SkillsList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<SkillsListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);

            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        public IActionResult SkillCreate() => View();

        [HttpPost]
        public async Task<IActionResult> SkillCreate(CreateSkillsDto SkillCreateDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsJsonAsync("Skills/SkillsCreate", SkillCreateDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SkillList");
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorMessage = await response.Content.ReadFromJsonAsync<List<string>>();
                    if (errorMessage != null)
                    {
                        foreach (var error in errorMessage) { ModelState.AddModelError("", error); }
                    }
                }
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var errorMessage = await response.Content.ReadFromJsonAsync<List<string>>();
                    if (errorMessage != null)
                    {
                        foreach (var error in errorMessage) { ModelState.AddModelError("", error); }
                    }
                }
                return View(SkillCreateDto);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }


        [HttpGet]
        public async Task<IActionResult> SkillUpdate(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Skills/GetByIdSkills?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadFromJsonAsync<UpdateSkillsDto>();
                    return View(value);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SkillUpdate(UpdateSkillsDto dto)
        {
            try
            {            
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PutAsJsonAsync("Skills/SkillsUpdate", dto);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("SkillList");
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorList = await response.Content.ReadFromJsonAsync<List<string>>();
                    if (errorList != null)
                    {
                        foreach (var error in errorList)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sunucu şu anda isteğe cevap veremiyor.");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "API bağlantısı sağlanamadı. Lütfen daha sonra tekrar deneyiniz.");
            }
            return View(dto);
        }

        public async Task<IActionResult> SkillDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var responsemessage = await client.DeleteAsync($"Skills/{id}");

                if (responsemessage.IsSuccessStatusCode)
                    return RedirectToAction("SkillList");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

    }
}
