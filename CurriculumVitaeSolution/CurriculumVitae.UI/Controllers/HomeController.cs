using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitae.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
