using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class CapacityCalculationController : Controller
    {
        [SessionAuthorize("read_FirmOrder")]
        public IActionResult FirmOrder()
        {
            return View();
        }

        [SessionAuthorize("read_SummaryOrder")]
        public IActionResult SummaryOrder()
        {
            return View();
        }
        
        [SessionAuthorize("read_ParameterCapacity")]
        public IActionResult ParameterCapacity()
        {
            return View();
        }
        
        [SessionAuthorize("read_ProcessCapacity")]
        public IActionResult ProcessCapacity()
        {
            return View();
        }
        
        [SessionAuthorize("read_ResultCapacity")]
        public IActionResult ResultCapacity()
        {
            return View();
        }
        
    }
}
