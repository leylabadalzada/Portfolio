using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ResumeController : Controller
    {
        readonly IResumeService _service;

        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResumeCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.CreateAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SelectResumeAsync(Guid id)
        {
            var result = await _service.SelectResumeAsync(id);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
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
