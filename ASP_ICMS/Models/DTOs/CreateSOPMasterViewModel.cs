using System.ComponentModel.DataAnnotations;

namespace ASP_ICMS.Models.DTOs
{
	public class CreateSOPMasterViewModel
	{
		[Required]
		public string SOPCode { get; set; }

		[Required]
		public string SOPName { get; set; }

		[Required]
		public int DivisionId { get; set; }

		[Required]
		public int SOPTypeId { get; set; }

		[Required]
		public int SOPAuditTypeId { get; set; }
		
		public string? Description { get; set; }
	}
}
