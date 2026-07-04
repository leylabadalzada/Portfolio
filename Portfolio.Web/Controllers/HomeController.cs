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
            var author = await _authorService.GetAsync();
            var specialities = await _specialityService.GetAllAsync();
            var resume = await _resumeService.GetSelectedResumeAsync();
            var vm = new HomeVM()
            {
                Author = author.Data,
                Resume = resume.Data,
                Specialities = specialities.Data
            };
            return View(vm);
        }
    }
}
