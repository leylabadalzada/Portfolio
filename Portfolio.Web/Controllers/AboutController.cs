using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        readonly IAuthorService _authorService;
        readonly ISpecialityService _specialityService;
        readonly ISocialMediaService _socialMediaService;
        readonly ILanguageService _languageService;

        public AboutController(IAuthorService authorService, ISpecialityService specialityService, ISocialMediaService socialMediaService, ILanguageService languageService)
        {
            _authorService = authorService;
            _specialityService = specialityService;
            _socialMediaService = socialMediaService;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync(),
                Speciality = await _specialityService.GetSpecialityAsync(),
                SocialMedias = await _socialMediaService.GetAllAsync(),
                Languages = await _languageService.GetAllAsync(),
            };
            return View(vm);
        }
    }
}
