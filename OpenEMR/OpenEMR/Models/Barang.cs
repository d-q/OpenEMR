using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenEMR.Models
{
    public class Barang
    {
        [Key]
        [Required]
        [Display(Name = "Kode Barang")]
        public string KodeBarang { get; set; }  // ID unik untuk setiap barang

        [Required]
        [Display(Name = "Nama Barang")]
        public string NamaBarang { get; set; }  // Nama obat atau produk

        [Display(Name = "Deskripsi Barang")]
        public string DeskripsiBarang { get; set; }  // Informasi detail tentang produk

        [Required]
        [Display(Name = "Kategori Barang")]
        public string KategoriBarang { get; set; }  // Kategori barang seperti obat generik, suplemen, dll.

        [Required]
        [Display(Name = "Satuan Unit")]
        public string SatuanUnit { get; set; }  // Misalnya, box, botol, strip

        [Required]
        [Display(Name = "Stok")]
        public int Stok { get; set; }  // Jumlah barang di gudang atau apotek

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Harga Jual")]
        public decimal HargaJual { get; set; }  // Harga jual ke pelanggan
    }
}
