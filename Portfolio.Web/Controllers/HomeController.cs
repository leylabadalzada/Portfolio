using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IAuthorService _authorService;
        readonly IResumeService _resumeService;

        public HomeController(IAuthorService authorService, IResumeService resumeService)
        {
            _authorService = authorService;
            _resumeService = resumeService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVM()
            {
                Author = await _authorService.GetAsync(),
                Resume = await _resumeService.GetSelectedResumeAsync()
            };
            return View(vm);
        }
    }
}
