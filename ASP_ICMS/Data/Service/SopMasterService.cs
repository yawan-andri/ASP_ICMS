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
                .Include(s => s.Division)
                .Where(s => s.Status)
                .ToListAsync();
        }
    }
}
