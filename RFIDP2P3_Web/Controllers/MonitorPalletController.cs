using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
	public class MonitorPalletController : Controller
    {
        [SessionAuthorize("read_MonitorPallet")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
