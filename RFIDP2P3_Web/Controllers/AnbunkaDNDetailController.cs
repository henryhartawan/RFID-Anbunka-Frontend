using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class AnbunkaDNDetailController : Controller
    {
        [SessionAuthorize("read_AnbunkaDNDetail")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
