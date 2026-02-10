using Microsoft.AspNetCore.Mvc;

namespace RFIDP2P3_Web.Controllers
{
    public class MasterOrderingController : Controller
    {
        public IActionResult MasterDock()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterLineOrder()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterSupplier()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterPackingSpec()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterPartOrder()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterDepth()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterIDPart()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterDataRoute()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCycleIssueLP()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCycleIssuePart()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterFinishGoods()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterUniqueLine()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCPL()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterProgressLane()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterGrouping()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterPartGrouping()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterDPR()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterCalendar()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterOEETT()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterParamJam()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
    }
}
