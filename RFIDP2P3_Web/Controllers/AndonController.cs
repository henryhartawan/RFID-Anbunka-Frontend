using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class AndonController : Controller
    {
        public IActionResult AndonMonitoringStockCasting()
        {
            return View();
        }

        public IActionResult AndonCentral()
        {
            return View();
        }

        public IActionResult AndonDelivery()
        {
            return View();
        }

        public IActionResult AndonSummaryReceiving()
        {
            return View();
        }

        public IActionResult AndonMonitoringStockEngine()
        {
            return View();
        }
	}
}
