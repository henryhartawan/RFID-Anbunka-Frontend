using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
	public class GRProController : Controller
    {
        [SessionAuthorize("read_GRPro")]
        public IActionResult Index()
        {
            return View();
        }
	}
}
