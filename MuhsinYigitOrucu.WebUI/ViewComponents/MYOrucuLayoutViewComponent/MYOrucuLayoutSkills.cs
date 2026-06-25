using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.SkillsSectionDto;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutSkills : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MYOrucuLayoutSkills(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Skills/SkillsSection");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<GetForSkillsSection>>();
                    return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutSkills.cshtml", values);
                }
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutSkills.cshtml", response.StatusCode);

            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutSkills.cshtml", ex.Message.ToString());
            }
        }
    }
}
