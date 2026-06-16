using Microsoft.AspNetCore.Mvc;
using RFIDP2P3_Web.Filters;

namespace RFIDP2P3_Web.Controllers
{
    public class OrderingController : Controller
    {
        [SessionAuthorize("read_Heijunka")]
        public IActionResult Heijunka()
        {
            return View();
        }

        [SessionAuthorize("read_PlanProduksi")]
        public IActionResult PlanProduksi()
        {
            return View();
        }

        [SessionAuthorize("read_PO")]
        public IActionResult PO()
        {
            return View();
        }

        [SessionAuthorize("read_POMilkrun")]
        public IActionResult POMilkrun()
        {
            return View();
        }

        [SessionAuthorize("read_HRP")]
        public IActionResult HRP()
        {
            return View();
        }

        [SessionAuthorize("read_UploadInitStock")]
        public IActionResult UploadInitStock()
        {
            return View();
        }

        [SessionAuthorize("read_Calculate")]
        public IActionResult Calculate()
        {
            return View();
        }

        [SessionAuthorize("read_Produksi")]
        public IActionResult Produksi()
        {
            return View();
        }

        [SessionAuthorize("read_PlanSupply")]
        public IActionResult PlanSupply()
        {
            return View();
        }

        [SessionAuthorize("read_PlanSupplyFinal")]
        public IActionResult PlanSupplyFinal()
        {
            return View();
        }

        [SessionAuthorize("read_StockFlow")]
        public IActionResult StockFlow()
        {
            return View();
        }

        [SessionAuthorize("read_SkemaPickup")]
        public IActionResult SkemaPickup()
        {
            return View();
        }

        [SessionAuthorize("read_Kebutuhan")]
        public IActionResult Kebutuhan()
        {
            return View();
        }

        [SessionAuthorize("read_PartPerCycle")]
        public IActionResult PartPerCycle()
        {
            return View();
        }

        [SessionAuthorize("read_LastInitStock")]
        public IActionResult LastInitStock()
        {
            return View();
        }

        [SessionAuthorize("read_DN")]
        public IActionResult DN()
        {
            return View();
        }

        [SessionAuthorize("read_TN")]
        public IActionResult TN()
        {
            return View();
        }

        [SessionAuthorize("read_GR")]
        public IActionResult Receiving()
        {
            return View();
        }

        [SessionAuthorize("read_ResumeReport")]
        public IActionResult ResumeReport()
        {
            return View();
        }

        [SessionAuthorize("read_CancelDN")]
        public IActionResult CancelDN()
        {
            return View();
        }

        [SessionAuthorize("read_SO")]
        public IActionResult SO()
        {
            return View();
        }

        [SessionAuthorize("read_ReportPackingInstruction")]
        public IActionResult ReportPackingInstruction()
        {
            return View();
        }

        [SessionAuthorize("read_UploadStockEngine")]
        public IActionResult UploadStockEngine()
        {
            return View();
        }

        [SessionAuthorize("read_ProduksiHeijunka")]
        public IActionResult ProduksiHeijunka()
        {
            return View();
        }
    }
}
