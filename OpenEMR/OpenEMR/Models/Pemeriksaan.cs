using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public enum JenisPemeriksaan
    {
        [Display(Name = "Laboratori")]
        Lab = 1,
        [Display(Name = "Tindakan Medis")]
        TindakanMedis = 2
    }

    public class Pemeriksaan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kode Tarif")]
        public string KodeTarif { get; set; }  // ID unik untuk setiap pemeriksaan atau tindakan

        [Required]
        [Display(Name = "Nama Pemeriksaan/Tindakan")]
        public string NamaPemeriksaan { get; set; }  // Nama pemeriksaan atau tindakan

        [Display(Name = "Deskripsi")]
        public string Deskripsi { get; set; }  // Penjelasan singkat mengenai prosedur atau tindakan

        [Required]
        [Display(Name = "Jenis Pemeriksaan")]
        public JenisPemeriksaan JenisPemeriksaan { get; set; }  // Jenis pemeriksaan sebagai enum

        [Required]
        [Display(Name = "Kategori Pemeriksaan")]
        public string KategoriPemeriksaan { get; set; }  // Kategori pemeriksaan sebagai string

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Tarif")]
        public decimal Tarif { get; set; }  // Tarif pemeriksaan
    }
}
