using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Resumes;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class ResumeController : Controller
    {
        readonly IResumeService _service;

        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAsync(false));
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
            return result ? RedirectToAction(nameof(Index)) : View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SelectResumeAsync(Guid id)
        {
            var result = await _service.SelectResumeAsync(id);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Failed");
        }
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Failed");
        }
    }
}
