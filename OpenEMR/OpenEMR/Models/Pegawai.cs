using System;
using System.ComponentModel.DataAnnotations;

namespace OpenEMR.Models
{
    public class Pegawai
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Nomor KTP/NIK")]
        public string NIK { get; set; }


        [Display(Name = "Tanggal Lahir")]
        [DataType(DataType.Date)]
        public DateTime TanggalLahir { get; set; }


        [Display(Name = "Tempat Lahir")]
        public string TempatLahir { get; set; }


        [Display(Name = "Jenis Kelamin")]
        public JenisKelamin JenisKelamin { get; set; }


        [Display(Name = "Alamat Rumah")]
        public string AlamatRumah { get; set; }


        [Display(Name = "Nomor Telepon Pribadi")]
        [DataType(DataType.PhoneNumber)]
        public string NomorTeleponPribadi { get; set; }


        [Display(Name = "Nomor Telepon Darurat")]
        [DataType(DataType.PhoneNumber)]
        public string NomorTeleponDarurat { get; set; }


        [Display(Name = "Alamat Email Pribadi")]
        [DataType(DataType.EmailAddress)]
        public string AlamatEmailPribadi { get; set; }


        [Display(Name = "Status Perkawinan")]
        public StatusPernikahan StatusPernikahan { get; set; }
    }
}
