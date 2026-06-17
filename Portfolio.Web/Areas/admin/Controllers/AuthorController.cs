using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Author;
using Portfolio.Service.ViewModels.General;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class AuthorController : Controller
    {
        readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAsync());
        }

        public async Task<IActionResult> Edit()
        {
            var author = await _service.GetAsync();
            var vm = new AuthorUpdateVM()
            {
                Description = author.Description,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Location = author.Location,
                Email = author.Email,
                Info = author.Info,
                isFreelanceAvailable = author.isFreelanceAvailable,
                BirthDate = new DateVM
                {
                    Year = author.BirthDate.Year,
                    Day = author.BirthDate.Day,
                    Month = author.BirthDate.Month
                }
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AuthorUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.UpdateAsync(vm);
            return result ? RedirectToAction(nameof(Index)) : View(vm);
        }

        public IActionResult ChangeImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImage(ChangeImageVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.ChangeImageAsync(vm);
            return result ? RedirectToAction(nameof(Index)) : View(vm);
        }
    }
}
