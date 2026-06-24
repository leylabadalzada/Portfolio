using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Core.Enums;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Language;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {
        readonly ILanguageService _service;

        public LanguageController(ILanguageService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Levels = Enum.GetValues<LanguageValue>()
                .Select(sm => new SelectListItem
                {
                    Text = sm.ToString(),
                    Value = sm.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.CreateAsync(vm);
            return result ? RedirectToAction(nameof(Index)) : BadRequest("Create failed.");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var language = await _service.GetSingleAsync(id);
            var vm = new LanguageCreateOrUpdateVM
            {
                Level = language.Level,
                Name = language.Name
            };
            ViewBag.Levels = Enum.GetValues<LanguageValue>()
               .Select(sm => new SelectListItem
               {
                   Text = sm.ToString(),
                   Value = sm.ToString()
               });
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, LanguageCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.UpdateAsync(id, vm);
            return result ? RedirectToAction(nameof(Index)) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            return result ? RedirectToAction(nameof(Index)) : BadRequest();
        }
    }
}
