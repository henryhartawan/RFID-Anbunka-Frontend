using Microsoft.AspNetCore.Mvc;

namespace RFIDP2P3_Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(String username)
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            if (HttpContext.Session.GetString("IsAccessDenied") != "1")
            {
                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.Remove("IsAccessDenied");
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}