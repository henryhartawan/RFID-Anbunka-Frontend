using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class MonthlyCalculationController : Controller
    {
        [SessionAuthorize("read_CustomerOrder")]
        public IActionResult CustomerOrder()
        {
            return View();
        }
        
    }
}
