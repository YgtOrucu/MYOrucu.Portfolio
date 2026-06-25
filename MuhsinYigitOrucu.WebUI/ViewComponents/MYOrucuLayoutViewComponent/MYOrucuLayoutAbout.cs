using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.AboutSectionDto;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutAbout : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MYOrucuLayoutAbout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Abouts/AboutSection");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<GetForAboutSection>();
                    return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutAbout.cshtml", values);
                }
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutAbout.cshtml", response.StatusCode);

            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutAbout.cshtml", ex.Message.ToString());
            }
        }
    }
}
