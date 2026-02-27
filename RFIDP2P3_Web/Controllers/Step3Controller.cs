using Microsoft.AspNetCore.Mvc;

namespace RFIDP2P3_Web.Controllers
{
    public class Step3Controller : Controller
    {
        public IActionResult StockFlowGeneral()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult MasterWarehouse()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult PrintPartAddress()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanSupply()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult SupplyMonitoring()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanDriver()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanInADM()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ManualCalling()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanDockIn()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanDockOut()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult ScanOutADM()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
        public IActionResult AndonTimelineDelivery()
        {
            return View();
        }
    }
}
