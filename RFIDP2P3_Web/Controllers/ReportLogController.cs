using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class ReportLogController : Controller
    {
        [SessionAuthorize("read_ReportLog")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
