using Microsoft.AspNetCore.Mvc;

namespace RFIDP2P3_Web.Controllers
{
    public class MonthlyController : Controller
    {
        public IActionResult MasterPartRouteFuture()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult Getsudo()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult CalculateMonthly()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCILPFuture()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCIPartFuture()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
    }
}
