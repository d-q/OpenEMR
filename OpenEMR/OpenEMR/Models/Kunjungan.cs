using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    [Table("Kunjungan")]
    public class Kunjungan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pasien")]
        public string PasienId { get; set; }
        [ForeignKey("PasienId")]
        public Pasien Pasien { get; set; }

        [Required]
        [Display(Name = "Dokter yang Dituju")]
        public int DokterId { get; set; }
        [ForeignKey("DokterId")]
        public Dokter Dokter { get; set; }

        [Required]
        [Display(Name = "Status Pasien")]
        public StatusPasien StatusPasien { get; set; }

        [Required]
        [Display(Name = "Waktu Mendaftar")]
        public DateTime WaktuMendaftar { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Penjamin")]
        public int PenjaminId { get; set; }
        [ForeignKey("PenjaminId")]
        public Penjamin Penjamin { get; set; }

        // Nomor pemeriksaan otomatis diisi
        [Required]
        [Display(Name = "Nomor Regis")]
        public string NomorRegis { get; set; }

        // Field gabungan
        [NotMapped] // Menandakan bahwa field ini tidak perlu dipetakan ke database
        [Display(Name = "Pasien dan Nomor Regis")]
        public string PasienDanNomorRegis => $"{NomorRegis} - {PasienId}";

        // Relasi ke tindakan
        public virtual ICollection<Tindakan> Tindakans { get; set; } = new List<Tindakan>(); // Inisialisasi koleksi




        [Display(Name = "Asesmen Nyeri")]
        public bool AdaNyeri { get; set; }

        [Display(Name = "Skala Nyeri")]
        public SkalaNyeriEnum? SkalaNyeri { get; set; } // Menggunakan enum untuk dropdown skala nyeri

        [Display(Name = "Skala Nyeri Berdasarkan Metode")]
        public string MetodeNyeri { get; set; }

        [Display(Name = "Lokasi Nyeri")]
        [StringLength(255)]
        public string LokasiNyeri { get; set; }

        [Display(Name = "Penyebab Nyeri")]
        [StringLength(255)]
        public string PenyebabNyeri { get; set; }

        [Display(Name = "Durasi Nyeri")]
        [StringLength(255)]
        public string DurasiNyeri { get; set; }

        [Display(Name = "Frekuensi Nyeri")]
        [StringLength(255)]
        public string FrekuensiNyeri { get; set; }



        // Denyut Jantung
        [Display(Name = "Denyut Jantung")]
        public string DenyutJantung { get; set; } // satuan per menit, teks biasa

        // Pernapasan
        [Display(Name = "Pernapasan")]
        public string Pernapasan { get; set; } // satuan per menit, teks biasa

        // Tekanan Darah
        [Display(Name = "Tekanan Darah Sistole")]
        public int TekananDarahSistole { get; set; } // Sistole per mmHg

        [Display(Name = "Tekanan Darah Diastole")]
        public int TekananDarahDiastole { get; set; } // Diastole per mmHg

        // Suhu Tubuh
        [Display(Name = "Suhu Tubuh")]
        public float SuhuTubuh { get; set; } // Derajat Celcius

        // Pemeriksaan Bagian Tubuh
        [Display(Name = "Kepala")]
        public string Kepala { get; set; } // Free text

        [Display(Name = "Mata")]
        public string Mata { get; set; } // Free text

        [Display(Name = "Telinga")]
        public string Telinga { get; set; } // Free text

        [Display(Name = "Hidung")]
        public string Hidung { get; set; } // Free text

        [Display(Name = "Rambut")]
        public string Rambut { get; set; } // Free text

        [Display(Name = "Bibir")]
        public string Bibir { get; set; } // Free text

        [Display(Name = "Gigi Geligi")]
        public string GigiGeligi { get; set; } // Free text

        [Display(Name = "Lidah")]
        public string Lidah { get; set; } // Free text

        [Display(Name = "Langit-langit")]
        public string LangitLangit { get; set; } // Free text

        [Display(Name = "Leher")]
        public string Leher { get; set; } // Free text

        [Display(Name = "Tenggorokan")]
        public string Tenggorokan { get; set; } // Free text

        [Display(Name = "Tonsil")]
        public string Tonsil { get; set; } // Free text

        [Display(Name = "Dada")]
        public string Dada { get; set; } // Free text

        [Display(Name = "Payudara")]
        public string Payudara { get; set; } // Free text

        [Display(Name = "Punggung")]
        public string Punggung { get; set; } // Free text

        [Display(Name = "Perut")]
        public string Perut { get; set; } // Free text

        [Display(Name = "Genital")]
        public string Genital { get; set; } // Free text

        [Display(Name = "Anus/Dubur")]
        public string Anus { get; set; } // Free text

        [Display(Name = "Lengan Atas")]
        public string LenganAtas { get; set; } // Free text

        [Display(Name = "Lengan Bawah")]
        public string LenganBawah { get; set; } // Free text

        [Display(Name = "Jari Tangan")]
        public string JariTangan { get; set; } // Free text

        [Display(Name = "Kuku Tangan")]
        public string KukuTangan { get; set; } // Free text

        [Display(Name = "Persendian Tangan")]
        public string PersendianTangan { get; set; } // Free text

        [Display(Name = "Tungkai Atas")]
        public string TungkaiAtas { get; set; } // Free text

        [Display(Name = "Tungkai Bawah")]
        public string TungkaiBawah { get; set; } // Free text

        [Display(Name = "Jari Kaki")]
        public string JariKaki { get; set; } // Free text

        [Display(Name = "Kuku Kaki")]
        public string KukuKaki { get; set; } // Free text

        [Display(Name = "Persendian Kaki")]
        public string PersendianKaki { get; set; } // Free text
    }

    public enum SkalaNyeriEnum
    {
        [Display(Name = "0 (No Pain)")]
        NoPain = 0,
        [Display(Name = "1")]
        One = 1,
        [Display(Name = "2 (Mild Pain)")]
        MildPain = 2,
        [Display(Name = "3")]
        Three = 3,
        [Display(Name = "4 (Moderate Pain)")]
        ModeratePain = 4,
        [Display(Name = "5")]
        Five = 5,
        [Display(Name = "6 (Severe Pain)")]
        SeverePain = 6,
        [Display(Name = "7")]
        Seven = 7,
        [Display(Name = "8 (Very Severe Pain)")]
        VerySeverePain = 8,
        [Display(Name = "9")]
        Nine = 9,
        [Display(Name = "10 (Worst Possible Pain)")]
        WorstPossiblePain = 10
    }
}
