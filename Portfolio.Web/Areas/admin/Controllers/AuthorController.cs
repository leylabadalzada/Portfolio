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

        public async Task<IActionResult> Update()
        {
            var author = await _service.GetAsync();
            var vm = new AuthorUpdateVM()
            {
                Description = author.Data.Description,
                FirstName = author.Data.FirstName,
                LastName = author.Data.LastName,
                Location = author.Data.Location,
                Info = author.Data.Info,
                isFreelanceAvailable = author.Data.isFreelanceAvailable,
                PhoneNumber = author.Data.PhoneNumber,
                BirthDate = new DateVM
                {
                    Year = author.Data.BirthDate.Year,
                    Day = author.Data.BirthDate.Day,
                    Month = author.Data.BirthDate.Month
                }
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var result = await _service.UpdateAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
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
            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(string email)
        {
            if (!ModelState.IsValid) return View(email);
            var result = await _service.ChangeEmailAsync(email);

            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
                return View(email);
            }
            TempData["NewEmail"] = email;
            return RedirectToAction(nameof(VerifyEmail));
        }

        public IActionResult VerifyEmail()
        {
            return View(new VerifyEmailVM());
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailVM vm)
        {
            var email = TempData["NewEmail"]?.ToString();

            // TempData bir dəfə oxunandan sonra silinir
            TempData.Keep("NewEmail");

            var result = await _service.VerifyEmailAsync(email, vm.OtpCode);

            if (!result.Result)
            {
                ModelState.AddModelError("internalError", result.Message!);
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
