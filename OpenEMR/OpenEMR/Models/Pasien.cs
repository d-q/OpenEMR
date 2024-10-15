using System;
using System.ComponentModel.DataAnnotations;

namespace OpenEMR.Models
{
    public class Pasien
    {

        public int ID { get; set; }

        [Key]
        [Required]
        [Display(Name = "RM")]
        public string NomorRekamMedis { get; set; }

        [Required]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [Display(Name = "Nomor Induk Kependudukan (NIK)")]
        [StringLength(16, MinimumLength = 16)]
        public string NIK { get; set; } = "9999999999999999";

        [Display(Name = "Nomor Identitas Lain (Khusus WNA)")]
        public string NomorIdentitasLain { get; set; }

        [Display(Name = "Nama Ibu Kandung")]
        public string NamaIbuKandung { get; set; }

        [Display(Name = "Tempat Lahir")]
        public string TempatLahir { get; set; }

        [Required]
        [Display(Name = "Tanggal Lahir")]
        [DataType(DataType.Date)]
        public DateTime TanggalLahir { get; set; }

        [Required]
        [Display(Name = "Jenis Kelamin")]
        public JenisKelamin JenisKelamin { get; set; }

        [Display(Name = "Agama")]
        public Agama Agama { get; set; }

        [Display(Name = "Suku")]
        public string Suku { get; set; }

        [Display(Name = "Bahasa yang Dikuasai")]
        public string BahasaYangDikuasai { get; set; }

        [Display(Name = "Alamat Lengkap")]
        public string AlamatLengkap { get; set; }

        [Display(Name = "RT")]
        [StringLength(3)]
        public string RT { get; set; }

        [Display(Name = "RW")]
        [StringLength(3)]
        public string RW { get; set; }

        [Display(Name = "Kelurahan/Desa")]
        public string KelurahanDesa { get; set; }

        [Display(Name = "Kecamatan")]
        public string Kecamatan { get; set; }

        [Display(Name = "Kota/Kabupaten")]
        public string KotaKabupaten { get; set; }

        [Display(Name = "Kode Pos")]
        public string KodePos { get; set; }

        [Display(Name = "Provinsi")]
        public string Provinsi { get; set; }

        [Display(Name = "Negara")]
        public string Negara { get; set; }

        [Display(Name = "Alamat Domisili")]
        public string AlamatDomisili { get; set; }

        [Display(Name = "RT Domisili")]
        [StringLength(3)]
        public string RTDomisili { get; set; }

        [Display(Name = "RW Domisili")]
        [StringLength(3)]
        public string RWDomisili { get; set; }

        [Display(Name = "Kelurahan/Desa Domisili")]
        public string KelurahanDesaDomisili { get; set; }

        [Display(Name = "Kecamatan Domisili")]
        public string KecamatanDomisili { get; set; }

        [Display(Name = "Kota/Kabupaten Domisili")]
        public string KotaKabupatenDomisili { get; set; }

        [Display(Name = "Kode Pos Domisili")]
        public string KodePosDomisili { get; set; }

        [Display(Name = "Provinsi Domisili")]
        public string ProvinsiDomisili { get; set; }

        [Display(Name = "Negara Domisili")]
        public string NegaraDomisili { get; set; }

        [Display(Name = "Nomor Telepon Rumah/Tempat Tinggal")]
        public string NomorTeleponRumah { get; set; }

        [Display(Name = "Nomor Telepon Selular Pasien")]
        public string NomorTeleponSelular { get; set; }

        [Display(Name = "Pendidikan")]
        public Pendidikan Pendidikan { get; set; }

        [Display(Name = "Pekerjaan")]
        public Pekerjaan Pekerjaan { get; set; }

        [Display(Name = "Status Pernikahan")]
        public StatusPernikahan StatusPernikahan { get; set; }
    }

    public enum JenisKelamin
    {
        [Display(Name = "Laki-laki")]
        LakiLaki = 1,
        [Display(Name = "Perempuan")]
        Perempuan = 2
    }

    public enum Agama
    {
        Islam = 1,
        [Display(Name = "Kristen (Protestan)")]
        KristenProtestan = 2,
        Katolik = 3,
        Hindu = 4,
        Budha = 5,
        Konghucu = 6,
        Penghayat = 7,
        [Display(Name = "Lain-lain")]
        LainLain = 8
    }

    public enum Pendidikan
    {
        [Display(Name = "Tidak Sekolah")]
        TidakSekolah = 0,
        SD = 1,
        [Display(Name = "SLTP Sederajat")]
        SLTP = 2,
        [Display(Name = "SLTA Sederajat")]
        SLTA = 3,
        [Display(Name = "D1-D3 Sederajat")]
        D1_D3 = 4,
        D4 = 5,
        S1 = 6,
        S2 = 7,
        S3 = 8
    }

    public enum Pekerjaan
    {
        [Display(Name = "Tidak Bekerja")]
        TidakBekerja = 0,
        PNS = 1,
        [Display(Name = "TNI/POLRI")]
        TNI_POLRI = 2,
        BUMN = 3,
        [Display(Name = "Pegawai Swasta/Wirausaha")]
        Swasta_Wirausaha = 4,
        [Display(Name = "Lain-lain")]
        LainLain = 5
    }

    public enum StatusPernikahan
    {
        [Display(Name = "Belum Kawin")]
        BelumKawin = 1,
        Kawin = 2,
        [Display(Name = "Cerai Hidup")]
        CeraiHidup = 3,
        [Display(Name = "Cerai Mati")]
        CeraiMati = 4
    }
}
