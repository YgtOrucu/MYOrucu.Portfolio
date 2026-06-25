using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutSidebar.cshtml");
        }
    }
}
