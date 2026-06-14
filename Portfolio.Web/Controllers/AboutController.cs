using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        readonly IAuthorService _authorService;
        readonly ISpecialityService _specialityService;


        public AboutController(IAuthorService authorService, ISpecialityService specialityService)
        {
            _authorService = authorService;
            _specialityService = specialityService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync(),
                Speciality = await _specialityService.GetSpecialityAsync()
            };
            return View(vm);
        }
    }
}
