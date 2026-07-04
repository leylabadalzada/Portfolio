using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        readonly IEmailService _emailService;
        readonly IAuthorService _authorService;

        public ContactController(IEmailService emailService, IAuthorService authorService)
        {
            _emailService = emailService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var author = await _authorService.GetAsync();
            var vm = new ContactVM { AuthorEmail = author.Data.Email, AuthorPhoneNumber = author.Data.PhoneNumber };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var result = await _emailService.SendEmailAsync(vm.Email, vm.Subject, vm.Body, true);
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
