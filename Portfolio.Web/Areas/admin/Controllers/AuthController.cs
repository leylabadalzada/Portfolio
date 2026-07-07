using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Auth;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _service.LoginAsync(vm);
            if (!result.Result)
            {
                ModelState.AddModelError("invalidinput", "Username or password is not correct");
                return View(vm);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return Redirect("/");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = await _service.ForgotPasswordAsync(vm.Email);

            if (!result.Result)
            {
                ModelState.AddModelError("", result.Message!);
                return View(vm);
            }

            TempData["SuccessMessage"] = result.Message;

            return RedirectToAction(nameof(Login));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction(nameof(Login));
            }

            var vm = new ResetPasswordVM
            {
                Email = email,
                Token = token
            };

            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = await _service.ResetPasswordAsync(vm);

            if (!result.Result)
            {
                ModelState.AddModelError("", result.Message!);
                return View(vm);
            }

            TempData["SuccessMessage"] = result.Message;

            return RedirectToAction(nameof(Login));
        }
    }
}
