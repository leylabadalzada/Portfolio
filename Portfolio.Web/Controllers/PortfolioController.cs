using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
