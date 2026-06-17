using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Core.Enums;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        readonly ISocialMediaService _service;

        public SocialMediaController(ISocialMediaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Names = Enum.GetValues<SocialMediaName>()
                .Select(sm => new SelectListItem
                {
                    Text = sm.ToString(),
                    Value = sm.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.CreateAsync(vm);
            return result ? RedirectToAction(nameof(Index)) : View(vm);
        }
    }
}
