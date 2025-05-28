using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMasterAuditType
    {
        public int Id { get; set; }
        public int SOPMasterId { get; set; }
        [ForeignKey("SOPMasterId")]
        public SOPMaster? SOPMaster { get; set; }
        public int SOPAuditTypeId { get; set; }
        [ForeignKey("SOPAuditTypeId")]
        public ChoiceList? SOPAuditType { get; set; }
        public DateTime? DateAdd { get; set; }
    }
}
