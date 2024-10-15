using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class DetailOrderFarmasi
    {
        [Key]
        public int Id { get; set; }

        // Relasi ke model OrderFarmasi
        [Required]
        [Display(Name = "Order Farmasi")]
        public int OrderFarmasiId { get; set; }
        [ForeignKey("OrderFarmasiId")]
        [Display(Name = "Order Farmasi")]
        public OrderFarmasi OrderFarmasi { get; set; }

        // Relasi ke model Barang
        [Required]
        [Display(Name = "Barang")]
        public string BarangId { get; set; }
        [ForeignKey("BarangId")]
        [Display(Name = "Barang")]
        public Barang Barang { get; set; }

        // Jumlah barang yang diorder
        [Required]
        [Display(Name = "Jumlah Barang")]
        public int Jumlah { get; set; }

        // Aturan pakai obat
        [Required]
        [Display(Name = "Aturan Pakai")]
        public string AturanPakai { get; set; }

        // Keterangan tambahan
        [Display(Name = "Keterangan")]
        public string Keterangan { get; set; }
    }
}
