using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
	public class ApprovalCancelController : Controller
    {
        [SessionAuthorize("read_ApprovalCancel")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
