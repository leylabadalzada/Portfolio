using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Education;
using Portfolio.Service.ViewModels.General;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        readonly IEducationService _service;

        public EducationController(IEducationService service)
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
        public async Task<IActionResult> Create(EducationCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.CreateAsync(vm);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Create failed.");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Remove failed.");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var education = await _service.GetAsync(id);
            var vm = new EducationCreateOrUpdateVM
            {
                Description = education.Description,
                Speciality = education.Speciality,
                isContinuing = education.isContinuing,
                University = education.University,
                StartDate = new DateVM { Day = education.StartDate.Value.Day, Month = education.StartDate.Value.Month, Year = education.StartDate.Value.Year },
                EndDate = education.EndDate != null ? new DateVM { Day = education.EndDate.Value.Day, Month = education.EndDate.Value.Month, Year = education.EndDate.Value.Year } : null
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, EducationCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.UpdateAsync(id, vm);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Update failed.");
        }
    }
}
