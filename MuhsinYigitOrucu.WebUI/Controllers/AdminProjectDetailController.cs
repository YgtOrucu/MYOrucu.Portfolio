using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.Dtos.ProjectDetailsDto;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProjectDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminProjectDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProjectDetailList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("ProjectDetails/ProjectDetailList");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<ProjectDetailsListDto>>();
                    return View(values);
                }
                return View(response.StatusCode);
            }
            catch (Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        public async Task<IActionResult> ProjectDetailCreate()
        {
            ViewBag.ProjectList = await GetProductInformations();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProjectDetailCreate(CreateProjectDetailsDto dto)
        {
            try
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(dto.ProjectId.ToString() ?? string.Empty), "ProjectId");
                content.Add(new StringContent(dto.Title ?? string.Empty), "Title");
                content.Add(new StringContent(dto.ShortDescription ?? string.Empty), "ShortDescription");
                content.Add(new StringContent(dto.FullDescription ?? string.Empty), "FullDescription");
                content.Add(new StringContent(dto.CoverImageUrl ?? "CoverImageUrl"), "CoverImageUrl");
                content.Add(new StringContent(dto.Category ?? string.Empty), "Category");
                content.Add(new StringContent(dto.Status ?? string.Empty), "Status");
                content.Add(new StringContent(dto.Year ?? string.Empty), "Year");
                content.Add(new StringContent(dto.Duration ?? string.Empty), "Duration");
                content.Add(new StringContent(dto.Role ?? string.Empty), "Role");
                content.Add(new StringContent(dto.TeamSize ?? string.Empty), "TeamSize");
                content.Add(new StringContent(dto.GithubLink ?? string.Empty), "GithubLink");
                content.Add(new StringContent(dto.LiveDemoUrl ?? string.Empty), "LiveDemoUrl");

                if (dto.UseTechnology != null)
                {
                    for (int i = 0; i < dto.UseTechnology.Count; i++)
                    {
                        content.Add(new StringContent(dto.UseTechnology[i] ?? string.Empty), $"UseTechnology[{i}]");
                    }
                }

                if (dto.Features != null)
                {
                    for (int i = 0; i < dto.Features.Count; i++)
                    {
                        content.Add(new StringContent(dto.Features[i] ?? string.Empty), $"Features[{i}]");
                    }
                }

                if (dto.Challenges != null)
                {
                    for (int i = 0; i < dto.Challenges.Count; i++)
                    {
                        content.Add(new StringContent(dto.Challenges[i] ?? string.Empty), $"Challenges[{i}]");
                    }
                }

                if (dto.GalleryImageFile != null && dto.GalleryImageFile.Any())
                {
                    foreach (var file in dto.GalleryImageFile)
                    {
                        var streamContent = new StreamContent(file.OpenReadStream());

                        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(streamContent, "GalleryImageFile", file.FileName);
                    }
                }

                if (dto.CoverImageFile != null)
                {
                    var streamContent = new StreamContent(dto.CoverImageFile.OpenReadStream());
                    content.Add(streamContent, "CoverImageFile", dto.CoverImageFile.FileName);
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PostAsync("ProjectDetails/ProjectDetailCreate", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProjectDetailList");
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var errorMessage = await response.Content.ReadFromJsonAsync<List<string>>();
                    if (errorMessage != null)
                    {
                        foreach (var error in errorMessage) { ModelState.AddModelError("", error); }
                    }
                }
                ViewBag.ProjectList = await GetProductInformations();
                return View(dto);
            }
            catch (Exception ex)
            {
                ViewBag.ProjectList = await GetProductInformations();
                return View(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProjectDetailUpdate(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync($"ProjectDetails/GetByIdProjectDetail?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    var value = await response.Content.ReadFromJsonAsync<UpdateProjectDetailsDto>();
                    ViewBag.ProjectList = await GetProductInformations();
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
        public async Task<IActionResult> ProjectDetailUpdate(UpdateProjectDetailsDto dto)
        {
            try
            {
                var content = new MultipartFormDataContent();

                content.Add(new StringContent(dto.ProjectDetailId.ToString()), "ProjectDetailId");
                content.Add(new StringContent(dto.ProjectId.ToString()), "ProjectId");
                content.Add(new StringContent(dto.Title ?? string.Empty), "Title");
                content.Add(new StringContent(dto.ShortDescription ?? string.Empty), "ShortDescription");
                content.Add(new StringContent(dto.FullDescription ?? string.Empty), "FullDescription");
                content.Add(new StringContent(dto.CoverImageUrl ?? "CoverImageUrl"), "CoverImageUrl");
                content.Add(new StringContent(dto.Category ?? string.Empty), "Category");
                content.Add(new StringContent(dto.Status ?? string.Empty), "Status");
                content.Add(new StringContent(dto.Year ?? string.Empty), "Year");
                content.Add(new StringContent(dto.Duration ?? string.Empty), "Duration");
                content.Add(new StringContent(dto.Role ?? string.Empty), "Role");
                content.Add(new StringContent(dto.TeamSize ?? string.Empty), "TeamSize");
                content.Add(new StringContent(dto.GithubLink ?? string.Empty), "GithubLink");
                content.Add(new StringContent(dto.LiveDemoUrl ?? string.Empty), "LiveDemoUrl");

                if (dto.UseTechnology != null)
                {
                    for (int i = 0; i < dto.UseTechnology.Count; i++)
                        content.Add(new StringContent(dto.UseTechnology[i] ?? string.Empty), $"UseTechnology[{i}]");
                }
                if (dto.Features != null)
                {
                    for (int i = 0; i < dto.Features.Count; i++)
                        content.Add(new StringContent(dto.Features[i] ?? string.Empty), $"Features[{i}]");
                }
                if (dto.Challenges != null)
                {
                    for (int i = 0; i < dto.Challenges.Count; i++)
                        content.Add(new StringContent(dto.Challenges[i] ?? string.Empty), $"Challenges[{i}]");
                }

                if (dto.GalleryImages != null)
                {
                    for (int i = 0; i < dto.GalleryImages.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dto.GalleryImages[i]))
                            content.Add(new StringContent(dto.GalleryImages[i]), $"GalleryImages[{i}]");
                    }
                }

                if (dto.GalleryImageFile != null && dto.GalleryImageFile.Any())
                {
                    foreach (var file in dto.GalleryImageFile)
                    {
                        var streamContent = new StreamContent(file.OpenReadStream());

                        streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                        content.Add(streamContent, "GalleryImageFile", file.FileName);
                    }
                }

                if (dto.DeleteGalleryImages != null && dto.DeleteGalleryImages.Any())
                {
                    for (int i = 0; i < dto.DeleteGalleryImages.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dto.DeleteGalleryImages[i]))
                        {
                            content.Add(new StringContent(dto.DeleteGalleryImages[i]), $"DeleteGalleryImages[{i}]");
                        }
                    }
                }

                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.PutAsync("ProjectDetails/ProjectDetailUpdate", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("ProjectDetailList");

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorList = await response.Content.ReadFromJsonAsync<List<string>>();
                    if (errorList != null)
                    {
                        foreach (var error in errorList) { ModelState.AddModelError("", error); }
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
            ViewBag.ProjectList = await GetProductInformations();
            return View(dto);
        }

        public async Task<IActionResult> ProjectDetailDelete(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.DeleteAsync($"ProjectDetails/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("ProjectDetailList");
            }
            catch (Exception ex)
            {
                ViewBag.ProjectList = await GetProductInformations();
                return View(ex.Message);
            }
            ViewBag.ProjectList = await GetProductInformations();
            return View();
        }

        private async Task<List<GetProjectNameWithAdminDetails>> GetProductInformations()
        {

            var client = _httpClientFactory.CreateClient("PortfolioClient");
            var response = await client.GetAsync("ProjectDetails/GetProjectNameWithDetailsPage");

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<GetProjectNameWithAdminDetails>>();
                return value!;
            }
            return new List<GetProjectNameWithAdminDetails>();
        }
    }
}