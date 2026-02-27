using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Web.ViewModels;

namespace Portfolio.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IAuthorService _author;

        public HomeController(IAuthorService author)
        {
            _author = author;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVM()
            {
                Author = await _author.GetAsync()
            };
            return View(vm);
        }
    }
}
