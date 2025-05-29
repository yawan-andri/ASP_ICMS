using ASP_ICMS.Models;
using Microsoft.EntityFrameworkCore;

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
            return await _context.SOPMaster
		        .Where(s => s.Status)
		        .Include(s => s.Division)
		        .Include(s => s.SOPTypes.OrderByDescending(t => t.DateAdd))
			        .ThenInclude(t => t.SOPType)
		        .Include(s => s.AuditTypes.OrderByDescending(a => a.DateAdd))
			        .ThenInclude(a => a.SOPAuditType)
		        .ToListAsync();
		}
    }
}
