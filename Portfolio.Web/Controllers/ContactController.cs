using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _emailService.SendEmailAsync(vm.Email, vm.Subject, vm.Body);
            if (!result.Result)
            {
                ModelState.AddModelError("internalservererror", result.Message);
                return View(vm);
            }
            TempData["SuccessMessage"] = "Mesajınız uğurla göndərildi! Tezliklə sizinlə əlaqə saxlanılacaq.";
            return RedirectToAction(nameof(Index));
        }
    }
}
