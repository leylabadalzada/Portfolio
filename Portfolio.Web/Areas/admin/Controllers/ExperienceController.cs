using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Experience;
using Portfolio.Service.ViewModels.General;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        readonly IExperienceService _service;

        public ExperienceController(IExperienceService service)
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
        public async Task<IActionResult> Create(ExperienceCreateOrUpdateVM vm)
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
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var education = await _service.GetAsync(id);
            var vm = new ExperienceCreateOrUpdateVM
            {
                Description = education.Data.Description,
                Position = education.Data.Position,
                isContinuing = education.Data.isContinuing,
                Company = education.Data.Company,
                StartDate = new DateVM { Day = education.Data.StartDate.Value.Day, Month = education.Data.StartDate.Value.Month, Year = education.Data.StartDate.Value.Year },
                EndDate = education.Data.EndDate != null ? new DateVM { Day = education.Data.EndDate.Value.Day, Month = education.Data.EndDate.Value.Month, Year = education.Data.EndDate.Value.Year } : null
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ExperienceCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.UpdateAsync(id, vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
