using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Field;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class FieldController : Controller
    {
        readonly IFieldService _service;

        public FieldController(IFieldService service)
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
        public async Task<IActionResult> Create(FieldCreateOrUpdateVM vm)
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
            var field = await _service.GetAsync(id);
            if (!field.Result) ModelState.AddModelError("notfound", field.Message);

            var vm = new FieldCreateOrUpdateVM { FieldName = field.Data.FieldName };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, FieldCreateOrUpdateVM vm)
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
