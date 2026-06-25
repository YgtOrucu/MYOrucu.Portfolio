using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuAdminLayoutViewComponent
{
    public class MYOrucuAdminLayoutSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuAdminLayoutViewComponent/MYOrucuAdminLayoutSidebar.cshtml");
        }
    }
}
