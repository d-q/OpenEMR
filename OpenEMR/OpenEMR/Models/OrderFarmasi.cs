using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class OrderFarmasi
    {
        [Key]
        public int Id { get; set; }

        // Relasi ke model Pegawai
        [Required]
        [Display(Name = "Pegawai")]
        public int PegawaiId { get; set; }
        [ForeignKey("PegawaiId")]
        [Display(Name = "Pegawai")]
        public Pegawai Pegawai { get; set; }

        // Relasi ke model Kunjungan
        [Required]
        [Display(Name = "Kunjungan")]
        public int KunjunganId { get; set; }
        [ForeignKey("KunjunganId")]
        [Display(Name = "Kunjungan")]
        public Kunjungan Kunjungan { get; set; }

        // Relasi ke model Pasien
        [Required]
        [Display(Name = "Pasien")]
        public string PasienId { get; set; }
        [ForeignKey("PasienId")]
        [Display(Name = "Pasien")]
        public Pasien Pasien { get; set; }

        // Waktu permintaan order otomatis terisi saat data disimpan
        [Required]
        [Display(Name = "Waktu Permintaan Order")]
        public DateTime WaktuPermintaanOrder { get; set; } = DateTime.Now;

        // Nomor pemeriksaan otomatis diisi
        [Required]
        [Display(Name = "Nomor Oerder")]
        public string NomorPemeriksaan { get; set; }

        // Method untuk generate nomor pemeriksaan secara otomatis
        public void GenerateNomorPemeriksaan(int lastNumber)
        {
            var today = DateTime.Now;
            var nomorUrut = (lastNumber + 1).ToString("D3"); // 3 digit angka urut yang bertambah setiap hari
            NomorPemeriksaan = $"{today:ddMMyy}{nomorUrut}";
        }
    }
}
