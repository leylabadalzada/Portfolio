using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTOs.Author;
using Portfolio.Service.Services.Abstractions;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _service.CreateAsync(dto);
            return result ? RedirectToAction(nameof(Index)) : View(dto);
        }

        public IActionResult ChangeImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImage(ChangeImageDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var result = await _service.ChangeImageAsync(dto);
            return result ? RedirectToAction(nameof(Index)) : View(dto);
        }
    }
}
