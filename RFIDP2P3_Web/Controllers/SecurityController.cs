using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class SecurityController : Controller
    {
        [SessionAuthorize("read_password")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
