using ASP_ICMS.Data.Service;
using ASP_ICMS.Models;
using ASP_ICMS.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var sopMasters = await _sopMasterService.GetSOPMasterAsync();
            return View(sopMasters);
        }

        public async Task<IActionResult> SOPMasterTablePartial()
        {
            var data = await _sopMasterService.GetSOPMasterAsync();
            return PartialView("_SOPMasterIndexPartial", data);
        }

        public async Task<IActionResult> GetDivisionList()
        {
			var divison = await _sopMasterService.GetChoicesByOption("Divisi");
			return Json(divison);
		}

		public async Task<IActionResult> GetSOPTypeList()
		{
			var soptype = await _sopMasterService.GetChoicesByOption("SOP Type");
			return Json(soptype);
		}

		public async Task<IActionResult> GetSOPAuditTypeList()
		{
			var sopaudittype = await _sopMasterService.GetChoicesByOption("SOP Audit Type");
			return Json(sopaudittype);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateSOPMasterViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Data tidak valid.");

			var check = await _sopMasterService.CheckDuplicateSOP(model);
			if (check == "DUPLICATE_CODE")
				return Conflict("Kode SOP ini sudah dipakai, silahkan edit atau input kode baru.");
			if (check == "DUPLICATE_NAME")
				return Conflict("Nama SOP ini sudah dipakai, silahkan edit atau input nama sop baru.");

			var result = await _sopMasterService.CreateSOPMaster(model);
			if (!result)
				return StatusCode(500, "Gagal menyimpan data.");

			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Edit([FromForm] EditSOPMasterViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest("Data tidak valid.");

			var result = await _sopMasterService.UpdateSOPMasterAsync(model);
			if (!result)
				return StatusCode(500, "Gagal memperbarui data.");

			return Ok();
		}

	}
}


