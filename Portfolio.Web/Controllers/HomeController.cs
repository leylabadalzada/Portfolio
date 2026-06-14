using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IAuthorService _authorService;
        readonly IResumeService _resumeService;
        readonly ISpecialityService _specialityService;

        public HomeController(IAuthorService authorService, IResumeService resumeService, ISpecialityService specialityService)
        {
            _authorService = authorService;
            _resumeService = resumeService;
            _specialityService = specialityService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVM()
            {
                Author = await _authorService.GetAsync(),
                Resume = await _resumeService.GetSelectedResumeAsync(),
                Specialities = await _specialityService.GetAsync()
            };
            return View(vm);
        }
    }
}
