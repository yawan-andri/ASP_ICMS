using ASP_ICMS.Models;
using ASP_ICMS.Models.DTOs;

namespace ASP_ICMS.Data.Service
{
    public interface ISopMasterService
    {
        Task<IEnumerable<SOPMaster>> GetSOPMasterAsync();
		Task<IEnumerable<ChoiceList>> GetChoicesByOption(string option);
		Task<string> CheckDuplicateSOP(CreateSOPMasterViewModel model);
		Task<bool> CreateSOPMaster(CreateSOPMasterViewModel model);
		Task<bool> UpdateSOPMasterAsync(EditSOPMasterViewModel model);
	}
}
