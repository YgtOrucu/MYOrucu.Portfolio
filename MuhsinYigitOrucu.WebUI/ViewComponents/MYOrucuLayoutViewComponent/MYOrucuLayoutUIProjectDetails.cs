using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.ProjectDetailsSectionDto;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutUIProjectDetails : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MYOrucuLayoutUIProjectDetails(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync($"ProjectDetails/ProjectSectionDetail/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<GetForProjectDetailDto>();
                    return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutUIProjectDetails.cshtml", values);
                }
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutUIProjectDetails.cshtml", response.StatusCode);

            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutUIProjectDetails.cshtml", ex.Message.ToString());
            }
        }
    }
}
