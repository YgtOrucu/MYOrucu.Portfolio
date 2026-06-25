using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutScript.cshtml");
        }
    }
}
