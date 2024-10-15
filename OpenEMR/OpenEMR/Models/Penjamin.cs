using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public enum StatusPasien
    {
        [Display(Name = "Pasien Lama")]
        Lama = 1,
        [Display(Name = "Pasien Baru")]
        Baru = 2
    }

    public class Penjamin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nama Penjamin")]
        public string NamaPenjamin { get; set; }

        [Required]
        [Display(Name = "Status Pasien")]
        public StatusPasien StatusPasien { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Tarif Jasa Administrasi")]
        public decimal TarifJasaAdministrasi { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Tarif Rumah Sakit")]
        public decimal TarifRumahSakit { get; set; }

        [NotMapped]
        [Display(Name = "Total Tarif")]
        public decimal TotalTarif
        {
            get { return TarifJasaAdministrasi + TarifRumahSakit; }
        }
    }
}
