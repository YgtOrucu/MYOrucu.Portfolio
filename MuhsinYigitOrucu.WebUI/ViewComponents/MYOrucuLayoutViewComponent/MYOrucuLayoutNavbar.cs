using Microsoft.AspNetCore.Mvc;
using MuhsinYigitOrucu.DtoLayer.UIDtos.FooterSectionDto;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutNavbar : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MYOrucuLayoutNavbar(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("PortfolioClient");
                var response = await client.GetAsync("Abouts/HeroSection");
                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<GetForFooterSection>();
                    return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutNavbar.cshtml", values);
                }
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutNavbar.cshtml", response.StatusCode);

            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutNavbar.cshtml", ex.Message.ToString());
            }
        }
    }
}
