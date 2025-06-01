using ASP_ICMS.Models;
using ASP_ICMS.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP_ICMS.Data.Service
{
    public class SopMasterService : ISopMasterService
    {
        private readonly ASP_ICMSContext _context;
        public SopMasterService(ASP_ICMSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SOPMaster>> GetSOPMaster()
        {
            var data = await _context.SOPMaster
		        .Where(s => s.Status)
		        .Include(s => s.Division)
                .Include(s => s.SOPTypes)
                    .ThenInclude(t => t.SOPType)
                .Include(s=> s.AuditTypes)
                    .ThenInclude(a => a.SOPAuditType)
		        .ToListAsync();

            foreach ( var sop in data)
            {
				sop.SOPTypes = sop.SOPTypes
					.OrderByDescending(t => t.DateAdd)
					.Take(1)
					.ToList();

				sop.AuditTypes = sop.AuditTypes
					.OrderByDescending(a => a.DateAdd)
					.Take(1)
					.ToList();
			}
            return data;
		}

		public async Task<IEnumerable<ChoiceList>> GetChoicesByOption(string option)
		{
			return await _context.ChoiceList
				.Where(c => c.Option == option && c.Status)
				.OrderBy(c => c.ChoiceName)
				.ToListAsync();
		}

		public async Task<string> CheckDuplicateSOP(CreateSOPMasterViewModel model)
		{
			if (await _context.SOPMaster.AnyAsync(s => s.SOPCode == model.SOPCode && s.Status))
				return "DUPLICATE_CODE";

			if (await _context.SOPMaster.AnyAsync(s => s.SOPName == model.SOPName && s.Status))
				return "DUPLICATE_NAME";

			return "OK";
		}
		public async Task<bool> CreateSOPMaster(CreateSOPMasterViewModel model)
		{
			var check = await CheckDuplicateSOP(model);
			if (check != "OK") return false;

			var sopMaster = new SOPMaster
			{
				SOPCode = model.SOPCode.ToUpper(),
				SOPName = model.SOPName.ToUpper(),
				DivisionId = model.DivisionId,
				StatusDate = null,
				Status = true,
				SOPTypes = new List<SOPMasterType>
				{
					new SOPMasterType
					{
						SOPTypeId = model.SOPTypeId,
						DateAdd = DateTime.Now
					}
				},
				AuditTypes = new List<SOPMasterAuditType>
				{
					new SOPMasterAuditType
					{
						SOPAuditTypeId = model.SOPAuditTypeId,
						Description =  (model.Description ?? "").ToUpper(),
						DateAdd = DateTime.Now
					}
				}
			};

			_context.SOPMaster.Add(sopMaster);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
