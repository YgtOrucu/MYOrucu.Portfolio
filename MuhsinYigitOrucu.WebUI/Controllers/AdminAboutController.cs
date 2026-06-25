using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.AboutDtos;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Abouts/AboutList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<AboutListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);

            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        public IActionResult AboutCreate() => View();

        [HttpPost]
        public async Task<IActionResult> AboutCreate(AboutCreateDto aboutCreateDto)
        {
            try
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(aboutCreateDto.FullName ?? string.Empty), "FullName");
                content.Add(new StringContent(aboutCreateDto.BrandInitials ?? string.Empty), "BrandInitials");
                content.Add(new StringContent(aboutCreateDto.ShortBio ?? string.Empty), "ShortBio");
                content.Add(new StringContent(aboutCreateDto.AvatarUrl ?? string.Empty), "AvatarUrl");
                content.Add(new StringContent(aboutCreateDto.Location ?? string.Empty), "Location");
                content.Add(new StringContent(aboutCreateDto.EmailAddress ?? string.Empty), "EmailAddress");
                content.Add(new StringContent(aboutCreateDto.PhoneNumber ?? string.Empty), "PhoneNumber");
                content.Add(new StringContent(aboutCreateDto.GithubUrl ?? string.Empty), "GithubUrl");
                content.Add(new StringContent(aboutCreateDto.LinkedinUrl ?? string.Empty), "LinkedinUrl");

                if (aboutCreateDto.TypewriterTitles != null)
                {
                    for (int i = 0; i < aboutCreateDto.TypewriterTitles.Count; i++)
                    {
                        content.Add(new StringContent(aboutCreateDto.TypewriterTitles[i] ?? string.Empty), $"TypewriterTitles[{i}]");
                    }
                }

                if (aboutCreateDto.BioParagraphs != null)
                {
                    for (int i = 0; i < aboutCreateDto.BioParagraphs.Count; i++)
                    {
                        content.Add(new StringContent(aboutCreateDto.BioParagraphs[i] ?? string.Empty), $"BioParagraphs[{i}]");
                    }
                }

                if (aboutCreateDto.QuickInfo != null)
                {
                    int index = 0;
                    foreach (var kvp in aboutCreateDto.QuickInfo)
                    {
                        content.Add(new StringContent(kvp.Key ?? string.Empty), $"QuickInfo[{index}].Key");
                        content.Add(new StringContent(kvp.Value ?? string.Empty), $"QuickInfo[{index}].Value");
                        index++;
                    }
                }

                if (aboutCreateDto.FormFile != null)
                {
                    var streamContent = new StreamContent(aboutCreateDto.FormFile.OpenReadStream());
                    content.Add(streamContent, "FormFile", aboutCreateDto.FormFile.FileName);
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsync("Abouts/AboutCreate", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("AboutList");
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
                return View(aboutCreateDto);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }


        [HttpGet]
        public async Task<IActionResult> AboutUpdate(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Abouts/GetByIdAbout?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadFromJsonAsync<AboutUpdateDto>();
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
        public async Task<IActionResult> AboutUpdate(AboutUpdateDto dto)
        {
            try
            {

                var content = new MultipartFormDataContent();

                content.Add(new StringContent(dto.AboutId.ToString() ?? string.Empty), "AboutId");
                content.Add(new StringContent(dto.FullName ?? string.Empty), "FullName");
                content.Add(new StringContent(dto.BrandInitials ?? string.Empty), "BrandInitials");
                content.Add(new StringContent(dto.ShortBio ?? string.Empty), "ShortBio");
                content.Add(new StringContent(dto.AvatarUrl ?? "asd"), "AvatarUrl");
                content.Add(new StringContent(dto.Location ?? string.Empty), "Location");
                content.Add(new StringContent(dto.EmailAddress ?? string.Empty), "EmailAddress");
                content.Add(new StringContent(dto.PhoneNumber ?? string.Empty), "PhoneNumber");
                content.Add(new StringContent(dto.GithubUrl ?? string.Empty), "GithubUrl");
                content.Add(new StringContent(dto.LinkedinUrl ?? string.Empty), "LinkedinUrl");

                if (dto.TypewriterTitles != null)
                {
                    for (int i = 0; i < dto.TypewriterTitles.Count; i++)
                    {
                        content.Add(new StringContent(dto.TypewriterTitles[i] ?? string.Empty), $"TypewriterTitles[{i}]");
                    }
                }

                if (dto.BioParagraphs != null)
                {
                    for (int i = 0; i < dto.BioParagraphs.Count; i++)
                    {
                        content.Add(new StringContent(dto.BioParagraphs[i] ?? string.Empty), $"BioParagraphs[{i}]");
                    }
                }

                if (dto.QuickInfo != null)
                {
                    int index = 0;
                    foreach (var kvp in dto.QuickInfo)
                    {
                        content.Add(new StringContent(kvp.Key ?? string.Empty), $"QuickInfo[{index}].Key");
                        content.Add(new StringContent(kvp.Value ?? string.Empty), $"QuickInfo[{index}].Value");
                        index++;
                    }
                }

                if (dto.FormFile != null)
                {
                    var streamContent = new StreamContent(dto.FormFile.OpenReadStream());
                    content.Add(streamContent, "FormFile", dto.FormFile.FileName);
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PutAsync("Abouts/AboutUpdate", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("AboutList");
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

        public async Task<IActionResult> AboutDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var responsemessage = await client.DeleteAsync($"Abouts/{id}");

                if (responsemessage.IsSuccessStatusCode)
                    return RedirectToAction("AboutList");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

    }
}
