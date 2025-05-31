using ASP_ICMS.Models;
using ASP_ICMS.Models.DTOs;

namespace ASP_ICMS.Data.Service
{
    public interface ISopMasterService
    {
        Task<IEnumerable<SOPMaster>> GetSOPMaster();
		Task<IEnumerable<ChoiceList>> GetChoicesByOption(string option);
		Task<bool> CreateSOPMasterAsync(CreateSOPMasterViewModel model);
	}
}
