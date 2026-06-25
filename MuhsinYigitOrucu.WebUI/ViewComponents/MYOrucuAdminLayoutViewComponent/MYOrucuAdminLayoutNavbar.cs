using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuAdminLayoutViewComponent
{
    public class MYOrucuAdminLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuAdminLayoutViewComponent/MYOrucuAdminLayoutNavbar.cshtml");
        }
    }
}
