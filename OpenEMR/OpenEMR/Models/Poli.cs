using System.ComponentModel.DataAnnotations;

namespace OpenEMR.Models
{
    public class Poli
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nama Poli")]
        public string NamaPoli { get; set; }
    }
}
