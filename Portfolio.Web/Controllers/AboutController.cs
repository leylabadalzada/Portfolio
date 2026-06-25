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
        readonly IEducationService _educationService;

        public AboutController(IAuthorService authorService, ISpecialityService specialityService, ISocialMediaService socialMediaService, ILanguageService languageService, IEducationService educationService)
        {
            _authorService = authorService;
            _specialityService = specialityService;
            _socialMediaService = socialMediaService;
            _languageService = languageService;
            _educationService = educationService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync(),
                Speciality = await _specialityService.GetAllAsync(),
                SocialMedias = await _socialMediaService.GetAllAsync(),
                Languages = await _languageService.GetAllAsync(),
                Education = await _educationService.GetAllAsync()
            };
            return View(vm);
        }
    }
}
