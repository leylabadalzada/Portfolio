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
        readonly IExperienceService _experienceService;

        public AboutController(IAuthorService authorService, ISpecialityService specialityService, ISocialMediaService socialMediaService, ILanguageService languageService, IEducationService educationService, IExperienceService experienceService)
        {
            _authorService = authorService;
            _specialityService = specialityService;
            _socialMediaService = socialMediaService;
            _languageService = languageService;
            _educationService = educationService;
            _experienceService = experienceService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync(),
                Speciality = await _specialityService.GetAllAsync(),
                SocialMedias = await _socialMediaService.GetAllAsync(),
                Languages = await _languageService.GetAllAsync(),
                Education = await _educationService.GetAllAsync(),
                Experiences = await _experienceService.GetAllAsync()
            };
            return View(vm);
        }
    }
}
