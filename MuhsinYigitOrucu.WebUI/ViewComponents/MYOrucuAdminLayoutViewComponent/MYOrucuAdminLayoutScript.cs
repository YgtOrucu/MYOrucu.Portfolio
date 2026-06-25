using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuAdminLayoutViewComponent
{
    public class MYOrucuAdminLayoutScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuAdminLayoutViewComponent/MYOrucuAdminLayoutScript.cshtml");
        }
    }
}
