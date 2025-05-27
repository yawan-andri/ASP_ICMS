using ASP_ICMS.Data.Service;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ICMS.Controllers
{
    public class SOPMasterController : Controller
    {
        private readonly ISopMasterService _sopMasterService;
        public SOPMasterController(ISopMasterService sopMasterService)
        {
            _sopMasterService = sopMasterService;
        }

        public async Task<IActionResult> Index()
        {
            var sopMasters = await _sopMasterService.GetSOPMaster();
            return View(sopMasters);
        }

        public async Task<IActionResult> TablePartial()
        {
            var data = await _sopMasterService.GetSOPMaster();
            return PartialView("_SOPMasterIndexPartial", data);
        }
    }
}


