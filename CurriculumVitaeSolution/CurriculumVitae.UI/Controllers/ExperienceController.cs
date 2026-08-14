using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitae.UI.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
