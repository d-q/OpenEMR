using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class Tindakan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pemeriksa")]
        public int PegawaiId { get; set; }
        [ForeignKey("PegawaiId")]
        public Pegawai Pemeriksa { get; set; }

        [Required]
        [Display(Name = "Kunjungan")]
        public int KunjunganId { get; set; }
        [ForeignKey("KunjunganId")]
        public Kunjungan Kunjungan { get; set; }

        [Required]
        [Display(Name = "Tindakan")]
        public int PemeriksaanId { get; set; }
        [ForeignKey("PemeriksaanId")]
        public Pemeriksaan TindakanMedis { get; set; }

        [Required]
        [Display(Name = "Waktu Pemeriksaan")]
        public DateTime WaktuPemeriksaan { get; set; } = DateTime.Now;
    }
}
