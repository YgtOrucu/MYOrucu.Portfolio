using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDtos;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProjectController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProjectList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Projects/ProjectList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<ProjectListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);

            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        public IActionResult ProjectCreate() => View();

        [HttpPost]
        public async Task<IActionResult> ProjectCreate(CreateProjectDto ProjectCreateDto)
        {
            try
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(ProjectCreateDto.Title ?? string.Empty), "Title");
                content.Add(new StringContent(ProjectCreateDto.MiniDescription ?? string.Empty), "MiniDescription");
                content.Add(new StringContent(ProjectCreateDto.ImageUrl ?? "ImageUrl"), "ImageUrl");
                content.Add(new StringContent(ProjectCreateDto.GithubLink ?? string.Empty), "GithubLink");
                content.Add(new StringContent(ProjectCreateDto.ShowOnHomePage.ToString()), "ShowOnHomePage");

                if (ProjectCreateDto.UseTechnology != null)
                {
                    for (int i = 0; i < ProjectCreateDto.UseTechnology.Count; i++)
                    {
                        content.Add(new StringContent(ProjectCreateDto.UseTechnology[i] ?? string.Empty), $"UseTechnology[{i}]");
                    }
                }

                if (ProjectCreateDto.FormFile != null)
                {
                    var streamContent = new StreamContent(ProjectCreateDto.FormFile.OpenReadStream());
                    content.Add(streamContent, "FormFile", ProjectCreateDto.FormFile.FileName);
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsync("Projects/ProjectCreate", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProjectList");
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
                return View(ProjectCreateDto);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProjectUpdate(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Projects/GetByIdProject?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadFromJsonAsync<UpdateProjectDto>();
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
        public async Task<IActionResult> ProjectUpdate(UpdateProjectDto dto)
        {
            try
            {

                var content = new MultipartFormDataContent();

                content.Add(new StringContent(dto.ProjectId.ToString() ?? string.Empty), "ProjectId");
                content.Add(new StringContent(dto.Title ?? string.Empty), "Title");
                content.Add(new StringContent(dto.MiniDescription ?? string.Empty), "MiniDescription");
                content.Add(new StringContent(dto.ImageUrl ?? "ImageUrl"), "ImageUrl");
                content.Add(new StringContent(dto.GithubLink ?? string.Empty), "GithubLink");
                content.Add(new StringContent(dto.ShowOnHomePage.ToString()), "ShowOnHomePage");

                if (dto.UseTechnology != null)
                {
                    for (int i = 0; i < dto.UseTechnology.Count; i++)
                    {
                        content.Add(new StringContent(dto.UseTechnology[i] ?? string.Empty), $"UseTechnology[{i}]");
                    }
                }

                if (dto.FormFile != null)
                {
                    var streamContent = new StreamContent(dto.FormFile.OpenReadStream());
                    content.Add(streamContent, "FormFile", dto.FormFile.FileName);
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PutAsync("Projects/ProjectUpdate", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("ProjectList");
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

        public async Task<IActionResult> ProjectDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var responsemessage = await client.DeleteAsync($"Projects/{id}");

                if (responsemessage.IsSuccessStatusCode)
                    return RedirectToAction("ProjectList");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }
    }
}
