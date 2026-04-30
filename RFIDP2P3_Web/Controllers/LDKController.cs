using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class LDKController : Controller
    {
        [SessionAuthorize("read_LDK")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
