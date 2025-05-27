using ASP_ICMS.Models;

namespace ASP_ICMS.Data.Service
{
    public interface ISopMasterService
    {
        Task<IEnumerable<SOPMaster>> GetSOPMaster();
        //Task<SOPMaster?> GetSOPMasterById(int id);
        //Task<SOPMaster> CreateSOPMaster(SOPMaster sopMaster);
        //Task<SOPMaster> UpdateSOPMaster(SOPMaster sopMaster);
        //Task<bool> DeleteSOPMaster(int id);
    }
}
