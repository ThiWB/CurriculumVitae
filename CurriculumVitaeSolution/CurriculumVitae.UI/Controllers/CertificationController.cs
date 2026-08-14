using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitae.UI.Controllers
{
    public class CertificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
