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


        public AboutController(IAuthorService authorService, ISpecialityService specialityService, ISocialMediaService socialMediaService)
        {
            _authorService = authorService;
            _specialityService = specialityService;
            _socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync(),
                Speciality = await _specialityService.GetSpecialityAsync(),
                SocialMedias = await _socialMediaService.GetAllAsync()
            };
            return View(vm);
        }
    }
}
