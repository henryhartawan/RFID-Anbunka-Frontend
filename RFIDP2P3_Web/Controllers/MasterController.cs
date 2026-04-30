using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class MasterController : Controller
    {
        [SessionAuthorize("read_master_user_group")]
        public IActionResult MasterUserGroup()
        {
            return View();
        }

        [SessionAuthorize("read_master_user_priv")]
        public IActionResult MasterPrivilege()
        {
            return View();
        }

        [SessionAuthorize("read_master_user")]
        public IActionResult MasterUser()
        {
            return View();
        }

        [SessionAuthorize("read_master_plant")]
        public IActionResult MasterPlant()
        {
            return View();
        }

        [SessionAuthorize("read_master_gedung")]
        public IActionResult MasterGedung()
        {
            return View();
        }

        [SessionAuthorize("read_master_line")]
        public IActionResult MasterLine()
        {
            return View();
        }

        [SessionAuthorize("read_master_shop")]
        public IActionResult MasterShop()
        {
            return View();
        }

        [SessionAuthorize("read_master_department")]
        public IActionResult MasterDepartment()
        {
            return View();
        }

        [SessionAuthorize("read_master_section")]
        public IActionResult MasterSection()
        {
            return View();
        }

        [SessionAuthorize("read_master_shift")]
        public IActionResult MasterShift()
        {
            return View();
        }

        [SessionAuthorize("read_master_pallet")]
        public IActionResult MasterPallet()
        {
            return View();
        }

        [SessionAuthorize("read_master_part")]
        public IActionResult MasterPart()
        {
            return View();
        }

        [SessionAuthorize("read_master_gi_p2")]
        public IActionResult MasterGIP2()
        {
            return View();
        }

        [SessionAuthorize("read_master_gi_p3")]
        public IActionResult MasterGIP3()
        {
            return View();
        }

        [SessionAuthorize("read_master_approval_ldk")]
        public IActionResult MasterApprovalLDK()
        {
            return View();
        }
    }
}
