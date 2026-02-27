using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
