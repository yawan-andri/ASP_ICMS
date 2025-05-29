using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMasterType
	{
		public int Id { get; set; }
		public int SOPMasterId { get; set; }
		public int SOPTypeId { get; set; }
		public DateTime DateAdd { get; set; } = DateTime.Now;

		public SOPMaster SOPMaster { get; set; }
		public ChoiceList SOPType { get; set; }
	}
}
