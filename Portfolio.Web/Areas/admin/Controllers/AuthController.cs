using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.ViewModels.Auth;

namespace Portfolio.Web.Areas.admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
