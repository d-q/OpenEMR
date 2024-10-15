using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class DetailOrderLab
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pemeriksa")]
        public int PegawaiId { get; set; }
        [ForeignKey("PegawaiId")]
        public Pegawai Pemeriksa { get; set; }

        [Required]
        [Display(Name = "Pemeriksaan")]
        public int PemeriksaanId { get; set; }
        [ForeignKey("PemeriksaanId")]
        public Pemeriksaan Pemeriksaan { get; set; }

        [Required]
        [Display(Name = "Waktu Dilakukan Pemeriksaan")]
        public DateTime WaktuDilakukanPemeriksaan { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Nilai Minimal Hasil")]
        public decimal NilaiMinimal { get; set; }

        [Required]
        [Display(Name = "Nilai Maksimal Hasil")]
        public decimal NilaiMaksimal { get; set; }

        [Required]
        [Display(Name = "Hasil Pemeriksaan")]
        public string HasilPemeriksaan { get; set; }

        [Required]
        [Display(Name = "Order Pemeriksaan")]
        public int OrderLabId { get; set; }
        [ForeignKey("OrderLabId")]
        public OrderLab OrderLab { get; set; }
    }
}
