using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class DailyCalculationController : Controller
    {
        [SessionAuthorize("read_OrderTmmin")]
        public IActionResult OrderTmmin()
        {
            return View();
        }
        
        [SessionAuthorize("read_OrderDdmi")]
        public IActionResult OrderDdmi()
        {
            return View();
        }
        
        [SessionAuthorize("read_OrderDdmiHistory")]
        public IActionResult OrderDdmiHistory()
        {
            return View();
        }
    }
}
