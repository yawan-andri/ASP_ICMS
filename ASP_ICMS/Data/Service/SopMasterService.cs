using ASP_ICMS.Models;
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
	}
}
