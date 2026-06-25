using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.ViewComponents.MYOrucuLayoutViewComponent
{
    public class MYOrucuLayoutContact : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/MYOrucuLayoutViewComponent/MYOrucuLayoutContact.cshtml");
        }
    }
}
