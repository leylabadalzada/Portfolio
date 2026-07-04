using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Speciality;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class SpecialityController : Controller
    {
        readonly ISpecialityService _service;

        public SpecialityController(ISpecialityService service)
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
        public async Task<IActionResult> Create(SpecialityCreateVM vm)
        {
            var result = await _service.CreateAsync(vm);
            return result.Result ? RedirectToAction(nameof(Index)) : View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SetMain(Guid id)
        {
            var result = await _service.SetMainAsync(id);
            return result.Result ? RedirectToAction(nameof(Index)) : BadRequest("Failed");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.RemoveAsync(id);
            return result.Result ? RedirectToAction(nameof(Index)) : BadRequest("Failed");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var name = await _service.GetAsync(id);
            var vm = new SpecialityUpdateVM() { Name = name.Data };
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, SpecialityUpdateVM vm)
        {
            var result = await _service.UpdateAsync(id, vm);
            return result.Result ? RedirectToAction(nameof(Index)) : BadRequest("Failed");
        }
    }
}
