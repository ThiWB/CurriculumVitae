using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitae.UI.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
