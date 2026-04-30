using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class MonthlyController : Controller
    {
        [SessionAuthorize("read_master_part_route_future")]
        public IActionResult MasterPartRouteFuture()
        {
            return View();
        }

        [SessionAuthorize("read_Getsudo")]
        public IActionResult Getsudo()
        {
            return View();
        }

        [SessionAuthorize("read_CalculateMonthly")]
        public IActionResult CalculateMonthly()
        {
            return View();
        }

        [SessionAuthorize("read_MasterCILPFuture")]
        public IActionResult MasterCILPFuture()
        {
            return View();
        }

        [SessionAuthorize("read_MasterCIPartFuture")]
        public IActionResult MasterCIPartFuture()
        {
            return View();
        }
    }
}
