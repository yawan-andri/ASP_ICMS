using System.ComponentModel.DataAnnotations;

namespace ASP_ICMS.Models
{
    public class ChoiceList
	{
		public int Id { get; set; }
		public string Option { get; set; } = null!;
		public string ChoiceName { get; set; } = null!;
		public DateTime? StatusDate { get; set; }
		public bool Status { get; set; } = true;

		public ICollection<SOPMaster> SOPMasters { get; set; }
		public ICollection<SOPMasterAuditType> SOPAuditTypes { get; set; }
		public ICollection<SOPMasterType> SOPTypes { get; set; }
	}
}
