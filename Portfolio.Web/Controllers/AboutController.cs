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
            var Author = await _authorService.GetAsync();
            var Speciality = await _specialityService.GetMainAsync();
            var SocialMedias = await _socialMediaService.GetAllAsync();
            var Languages = await _languageService.GetAllAsync();
            var Education = await _educationService.GetAllAsync();
            var Experiences = await _experienceService.GetAllAsync();
            var vm = new AboutVM
            {
                Author = Author.Data,
                Education = Education.Data,
                Experiences = Experiences.Data,
                Languages = Languages.Data,
                SocialMedias = SocialMedias.Data,
                Speciality = Speciality.Data
            };
            return View(vm);
        }
    }
}
