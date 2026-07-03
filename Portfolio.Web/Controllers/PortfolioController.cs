using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class PortfolioController : Controller
    {
        readonly IProjectService _projectService;

        public PortfolioController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllAsync();
            if (!projects.Result)
            {
                {
                    ModelState.AddModelError("internalError", projects.Message!);
                }
            }
            var vm = new PortfolioVM
            {
                Projects = projects.Data
            };
            return View(vm);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _projectService.GetAsync(id);
            if (!result.Result)
            {
                {
                    ModelState.AddModelError("internalError", result.Message!);
                }
            }
            return View(result.Data);
        }
    }
}
