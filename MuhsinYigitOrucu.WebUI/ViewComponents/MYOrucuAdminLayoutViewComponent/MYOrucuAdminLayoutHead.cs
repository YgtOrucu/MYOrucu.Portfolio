using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuAdminLayoutViewComponent
{
    public class MYOrucuAdminLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuAdminLayoutViewComponent/MYOrucuAdminLayoutHead.cshtml");
        }
    }
}
