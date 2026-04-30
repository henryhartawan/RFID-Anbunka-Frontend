using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class MasterOrderingController : Controller
    {
        [SessionAuthorize("read_master_dock")]
        public IActionResult MasterDock()
        {
            return View();
        }

        [SessionAuthorize("read_master_line_order")]
        public IActionResult MasterLineOrder()
        {
            return View();
        }

        [SessionAuthorize("read_master_supplier")]
        public IActionResult MasterSupplier()
        {
            return View();
        }

        [SessionAuthorize("read_master_packing_spec")]
        public IActionResult MasterPackingSpec()
        {
            return View();
        }

        [SessionAuthorize("read_master_part_order")]
        public IActionResult MasterPartOrder()
        {
            return View();
        }

        [SessionAuthorize("read_master_depth")]
        public IActionResult MasterDepth()
        {
            return View();
        }

        [SessionAuthorize("read_master_id_part")]
        public IActionResult MasterIDPart()
        {
            return View();
        }

        [SessionAuthorize("read_master_data_route")]
        public IActionResult MasterDataRoute()
        {
            return View();
        }

        [SessionAuthorize("read_master_cycle_issue_lp")]
        public IActionResult MasterCycleIssueLP()
        {
            return View();
        }

        [SessionAuthorize("read_master_cycle_issue_part")]
        public IActionResult MasterCycleIssuePart()
        {
            return View();
        }

        [SessionAuthorize("read_master_finish_goods")]
        public IActionResult MasterFinishGoods()
        {
            return View();
        }

        [SessionAuthorize("read_master_unique_line")]
        public IActionResult MasterUniqueLine()
        {
            return View();
        }

        [SessionAuthorize("read_master_cpl")]
        public IActionResult MasterCPL()
        {
            return View();
        }

        [SessionAuthorize("read_master_progress_lane")]
        public IActionResult MasterProgressLane()
        {
            return View();
        }

        [SessionAuthorize("read_master_grouping")]
        public IActionResult MasterGrouping()
        {
            return View();
        }

        [SessionAuthorize("read_master_part_grouping")]
        public IActionResult MasterPartGrouping()
        {
            return View();
        }

        [SessionAuthorize("read_master_dpr")]
        public IActionResult MasterDPR()
        {
            return View();
        }

        [SessionAuthorize("read_master_calendar")]
        public IActionResult MasterCalendar()
        {
            return View();
        }

        [SessionAuthorize("read_master_oee_tt")]
        public IActionResult MasterOEETT()
        {
            return View();
        }

        [SessionAuthorize("read_master_param_jam")]
        public IActionResult MasterParamJam()
        {
            return View();
        }

        [SessionAuthorize("read_MasterCustomerOrder")]
        public IActionResult MasterCustomerOrder()
        {
            return View();
        }

        [SessionAuthorize("read_MasterSuffixToUnique")]
        public IActionResult MasterSuffixToUnique()
        {
            return View();
        }

        [SessionAuthorize("read_AddMasterCalendar")]
        public IActionResult AddMasterCalendar()
        {
            return View();
        }

        [SessionAuthorize("read_MasterOEETTFuture")]
        public IActionResult MasterOEETTFuture()
        {
            return View();
        }
    }
}
