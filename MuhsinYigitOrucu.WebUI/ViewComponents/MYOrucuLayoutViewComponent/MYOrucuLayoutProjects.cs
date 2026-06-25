using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectSectionDto;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutProjects : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MYOrucuLayoutProjects(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Projects/ProjectSection");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<GetForProjectSection>>();
                    return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutProjects.cshtml", values);
                }
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutProjects.cshtml", response.StatusCode);

            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutProjects.cshtml", ex.Message.ToString());
            }
        }
    }
}
