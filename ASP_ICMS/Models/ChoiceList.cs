using System.ComponentModel.DataAnnotations;

namespace ASP_ICMS.Models
{
    public class ChoiceList
    {
        public int Id { get; set; }
        [Required]
        public string Option { get; set; } = null!;
        [Required]
        public string ChoiceName { get; set; } = null!;
        public DateTime? StatusDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
