using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.ExperienceDtos;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminExperienceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminExperienceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ExperienceList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Experiences/ExperienceList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<ExperienceListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);

            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        public IActionResult ExperienceCreate() => View();

        [HttpPost]
        public async Task<IActionResult> ExperienceCreate(CreateExperienceDto createExperienceDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsJsonAsync("Experiences/ExperienceCreate", createExperienceDto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ExperienceList");
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
                return View(createExperienceDto);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }


        [HttpGet]
        public async Task<IActionResult> ExperienceUpdate(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Experiences/GetByIdExperience?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadFromJsonAsync<UpdateExperienceDto>();
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
        public async Task<IActionResult> ExperienceUpdate(UpdateExperienceDto dto)
        {
            try
            {
 
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PutAsJsonAsync("Experiences/ExperienceUpdate", dto);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("ExperienceList");
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

        public async Task<IActionResult> ExperienceDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var responsemessage = await client.DeleteAsync($"Experiences/{id}");

                if (responsemessage.IsSuccessStatusCode)
                    return RedirectToAction("ExperienceList");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

    }
}
