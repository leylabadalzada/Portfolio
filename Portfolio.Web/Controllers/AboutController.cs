using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
