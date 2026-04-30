using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
	public class PlanScheduleController : Controller
    {
        [SessionAuthorize("read_MasterPlanSchedule")]
        public IActionResult Index()
        {
            return View();
        }
	}
}
