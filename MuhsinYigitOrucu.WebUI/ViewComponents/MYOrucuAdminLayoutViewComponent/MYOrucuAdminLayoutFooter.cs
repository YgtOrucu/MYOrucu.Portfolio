using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuAdminLayoutViewComponent
{
    public class MYOrucuAdminLayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuAdminLayoutViewComponent/MYOrucuAdminLayoutFooter.cshtml");
        }
    }
}
