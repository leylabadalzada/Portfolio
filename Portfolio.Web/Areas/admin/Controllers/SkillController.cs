using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Core.Enums;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Field;
using Portfolio.Service.ViewModels.Skill;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillController : Controller
    {
        readonly ISkillService _skillService;
        readonly IFieldService _fieldService;

        public SkillController(ISkillService service, IFieldService fieldService)
        {
            _skillService = service;
            _fieldService = fieldService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _skillService.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            await GenerateFieldViewBagAsync();
            GenerateViewBags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                await GenerateFieldViewBagAsync();
                GenerateViewBags();
                return View(vm);
            }
            var result = await _skillService.CreateAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var skill = await _skillService.GetAsync(id);
            if (!skill.Result)
            {
                ModelState.AddModelError("internalError", skill.Message!);
            }

            var vm = new SkillUpdateVM
            {
                Level = skill.Data.Level,
                Name = skill.Data.Name
            };
            GenerateViewBags();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, SkillUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                GenerateViewBags();
                return View(vm);
            }
            var result = await _skillService.UpdateAsync(id, vm);
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
            var result = await _skillService.RemoveAsync(id);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }

            return RedirectToAction(nameof(Index));
        }

        async Task GenerateFieldViewBagAsync()
        {
            var fields = await _fieldService.GetAllAsync();

            ViewBag.Fields = (fields.Data ?? new List<FieldGetVM>())
                .Select(x => new SelectListItem
                {
                    Text = x.FieldName,
                    Value = x.Id.ToString()
                })
                .ToList();
        }

        void GenerateViewBags()
        {

            ViewBag.Skills = Enum.GetValues<SkillType>()
               .Select(sm => new SelectListItem
               {
                   Text = sm.ToString(),
                   Value = sm.ToString()
               });
            ViewBag.Levels = Enum.GetValues<SkillLevel>()
               .Select(sm => new SelectListItem
               {
                   Text = sm.ToString(),
                   Value = sm.ToString()
               });
        }
    }
}
