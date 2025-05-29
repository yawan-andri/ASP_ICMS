using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMaster
	{
		public int Id { get; set; }
		public string SOPCode { get; set; } = null!;
		public string SOPName { get; set; } = null!;
		public int DivisionId { get; set; }
		public DateTime? StatusDate { get; set; }
		public bool Status { get; set; } = true;

		public ChoiceList Division { get; set; }
		
		public ICollection<SOPMasterAuditType> AuditTypes { get; set; }
		public ICollection<SOPMasterType> SOPTypes { get; set; }
	}
}
