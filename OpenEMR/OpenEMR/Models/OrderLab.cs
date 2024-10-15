using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class OrderLab
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Petugas")]
        public int PegawaiId { get; set; }
        [ForeignKey("PegawaiId")]
        public Pegawai Pemeriksa { get; set; }

        [Required]
        [Display(Name = "Waktu Permintaan")]
        public DateTime WaktuPermintaanOrder { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Nomor Order")]
        public string NomorPemeriksaan { get; set; }

        [Required]
        [Display(Name = "Kunjungan")]
        public int KunjunganId { get; set; }
        [ForeignKey("KunjunganId")]
        public Kunjungan Kunjungan { get; set; }

        // Nomor pemeriksaan otomatis diisi
        [Required]
        [Display(Name = "Nomor Order")]
        public string NomorOrderLab { get; set; }

        // Method untuk generate nomor pemeriksaan secara otomatis
        public void GenerateNomorOrderLab(int lastNumber)
        {
            var today = DateTime.Now;
            var nomorUrut = (lastNumber + 1).ToString("D3"); // 3 digit angka urut yang bertambah setiap hari
            NomorOrderLab = $"{today:ddMMyy}{nomorUrut}";
        }
    }
}
