using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class Dokter : Pegawai
    {
        [Required]
        [Display(Name = "Nomor SIP")]
        public string NomorSIP { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Tarip Pemeriksaan")]
        public decimal TaripPemeriksaan { get; set; }

        [Required]
        [Display(Name = "Poli")]
        public int PoliId { get; set; }

        [ForeignKey("PoliId")]
        public Poli Poli { get; set; }
    }
}