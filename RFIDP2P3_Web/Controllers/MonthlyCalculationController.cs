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
        
        [SessionAuthorize("read_MonthlySummaryOrder")]
        public IActionResult MonthlySummaryOrder()
        {
            return View();
        }
        
        [SessionAuthorize("read_ParameterRecoverySct")]
        public IActionResult ParameterRecoverySct()
        {
            return View();
        }
        
        [SessionAuthorize("read_TargetStockParam")]
        public IActionResult TargetStockParam()
        {
            return View();
        }
        
        [SessionAuthorize("read_ProcessMonthlyPlan")]
        public IActionResult ProcessMonthlyPlan()
        {
            return View();
        }
        
        [SessionAuthorize("read_TargetStockResult")]
                public IActionResult TargetStockResult()
                {
                    return View();
                }
        
        [SessionAuthorize("read_MonthlyPlanResults")]
        public IActionResult MonthlyPlanResults()
        {
            return View();
        }
    }
}
