using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMasterAuditType
	{
		public int Id { get; set; }
		public int SOPMasterId { get; set; }
		public int SOPAuditTypeId { get; set; }
		public string Description { get; set; }
		public DateTime DateAdd { get; set; } = DateTime.Now;

		public SOPMaster SOPMaster { get; set; }
		public ChoiceList SOPAuditType { get; set; }
	}
}
