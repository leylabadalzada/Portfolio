using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Core.Enums;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.SocialMedia;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
        public async Task<IActionResult> Create(SocialMediaCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.CreateAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var media = await _service.GetAsync(id);
            var vm = new SocialMediaCreateOrUpdateVM()
            {
                SocialMediaName = media.Data.SocialMediaName,
                Url = media.Data.Url,
                UserName = media.Data.UserName
            };
            ViewBag.Names = Enum.GetValues<SocialMediaName>()
                .Select(sm => new SelectListItem
                {
                    Text = sm.ToString(),
                    Value = sm.ToString()
                });
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, SocialMediaCreateOrUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.UpdateAsync(id, vm);
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
