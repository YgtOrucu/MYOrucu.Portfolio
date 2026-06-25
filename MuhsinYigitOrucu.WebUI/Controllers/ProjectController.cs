using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MuhsinYigitOrucu.WebUI.Controllers
{
    [AllowAnonymous]
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
