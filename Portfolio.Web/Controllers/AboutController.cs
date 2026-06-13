using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        readonly IAuthorService _authorService;


        public AboutController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AboutVM
            {
                Author = await _authorService.GetAsync()
            };
            return View(vm);
        }
    }
}
