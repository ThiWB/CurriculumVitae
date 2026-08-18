using Microsoft.AspNetCore.Mvc;
using CurriculumVitae.Core.Application.ServiceContracts;
using CurriculumVitae.Core.Application.ViewModels;

namespace CurriculumVitae.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectsService _projectsService;
        private readonly IExperiencesService _experiencesService;
        private readonly ICertificationsService _certificationsService;

        public HomeController(IProjectsService projectsService, IExperiencesService experiencesService, ICertificationsService certificationsService)
        {
            _projectsService = projectsService;
            _experiencesService = experiencesService;
            _certificationsService = certificationsService;
        }

        public async Task <IActionResult> Index()
        {
            var model = new HomeViewModel
            {
                Projects = await _projectsService.GetAllAsync(),
                Experiences = await _experiencesService.GetAllAsync(),
                Certifications = await _certificationsService.GetAllAsync()
            };

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
