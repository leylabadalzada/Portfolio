using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
