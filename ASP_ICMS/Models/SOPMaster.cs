using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ICMS.Models
{
    public class SOPMaster
    {
        public int Id { get; set; }
        [Required]
        public string SOPCode { get; set; } = null!;
        [Required]
        public string SOPName { get; set; } = null!;
        [Required]
        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public ChoiceList? Division { get; set; }
        public bool Status { get; set; } = true;

    }
}
