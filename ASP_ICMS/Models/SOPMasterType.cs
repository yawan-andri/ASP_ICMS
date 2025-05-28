using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMasterType
    {
        public int Id { get; set; }
        public int SOPMasterId { get; set; }
        [ForeignKey("SOPMasterId")]
        public SOPMaster? SOPMaster { get; set; }
        public int SOPTypeId { get; set; }
        [ForeignKey("SOPTypeId")]
        public ChoiceList? SOPType { get; set; }
        public DateTime? DateAdd { get; set; }
    }
}
