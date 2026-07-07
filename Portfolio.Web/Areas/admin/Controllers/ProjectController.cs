using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Project;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.CreateAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var project = await _service.GetAsync(id);
            if (!project.Result)
            {
                ModelState.AddModelError("internalError", project.Message!);
            }
            var vm = new ProjectUpdateVM()
            {
                Description = project.Data.Description,
                GitHubURL = project.Data.GitHubURL,
                IsFeatured = project.Data.IsFeatured,
                LiveURL = project.Data.LiveURL,
                ProjectName = project.Data.ProjectName,
                ShortDescription = project.Data.ShortDescription,
                ImageName = project.Data.Image
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ProjectUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.UpdateAsync(id, vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
