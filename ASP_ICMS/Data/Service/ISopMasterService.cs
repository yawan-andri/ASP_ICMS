using ASP_ICMS.Models;

namespace ASP_ICMS.Data.Service
{
    public interface ISopMasterService
    {
        Task<IEnumerable<SOPMaster>> GetSOPMaster();
		Task<IEnumerable<ChoiceList>> GetChoicesByOption(string option);
	}
}
