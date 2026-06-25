using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        [HttpGet]
        public IActionResult GetAllProject()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProjectDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
