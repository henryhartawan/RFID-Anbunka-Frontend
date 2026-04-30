using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class Step3Controller : Controller
    {
        [SessionAuthorize("read_StockFlowGeneral")]
        public IActionResult StockFlowGeneral()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_master_warehouse")]
        public IActionResult MasterWarehouse()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_PrintPartAddress")]
        public IActionResult PrintPartAddress()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanSupply")]
        public IActionResult ScanSupply()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_SupplyMonitoring")]
        public IActionResult SupplyMonitoring()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanDriver")]
        public IActionResult ScanDriver()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanInADM")]
        public IActionResult ScanInADM()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ManualCalling")]
        public IActionResult ManualCalling()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanDockIn")]
        public IActionResult ScanDockIn()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanDockOut")]
        public IActionResult ScanDockOut()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ScanOutADM")]
        public IActionResult ScanOutADM()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        public IActionResult AndonTimelineDelivery()
        {
            return View();
        }

        [SessionAuthorize("read_ScanBoxLabel")]
        public IActionResult ScanBoxLabel()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_ReprintSKID")]
        public IActionResult ReprintSKID()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }

        [SessionAuthorize("read_MonitoringSKID")]
        public IActionResult MonitoringSKID()
        {
            if (HttpContext.Session.GetString("PIC_ID") != null) return View();
            else return RedirectToAction("Index", "Login");
        }
    }
}
