using Microsoft.EntityFrameworkCore;
using OpenEMR.Models;

namespace OpenEMR.Data
{
    public class OpenEMRContext : DbContext
    {
        public OpenEMRContext(DbContextOptions<OpenEMRContext> options)
            : base(options)
        {
        }

        public DbSet<OpenEMR.Models.Pasien> Pasien { get; set; }

        public DbSet<OpenEMR.Models.Poli> Poli { get; set; }

        public DbSet<OpenEMR.Models.Penjamin> Penjamin { get; set; }

        public DbSet<OpenEMR.Models.Pemeriksaan> Pemeriksaan { get; set; }

        public DbSet<OpenEMR.Models.Barang> Barang { get; set; }

        public DbSet<OpenEMR.Models.Pegawai> Pegawai { get; set; }

        public DbSet<OpenEMR.Models.Dokter> Dokter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pegawai>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Pegawai>("Pegawai")
                .HasValue<Dokter>("Dokter");

            modelBuilder.Entity<Tindakan>()
                .HasOne(t => t.Pemeriksa)
                .WithMany()
                .HasForeignKey(t => t.PegawaiId)
                .OnDelete(DeleteBehavior.Restrict); // Atau DeleteBehavior.NoAction

            modelBuilder.Entity<Tindakan>()
                .HasOne(t => t.Kunjungan)
                .WithMany()
                .HasForeignKey(t => t.KunjunganId)
                .OnDelete(DeleteBehavior.Restrict); // Atau DeleteBehavior.NoAction

            modelBuilder.Entity<OrderLab>()
                .HasOne(o => o.Pemeriksa)
                .WithMany()
                .HasForeignKey(o => o.PegawaiId)
                .OnDelete(DeleteBehavior.NoAction);  // Tambahkan aturan ini

            modelBuilder.Entity<OrderLab>()
                .HasOne(o => o.Kunjungan)
                .WithMany()
                .HasForeignKey(o => o.KunjunganId)
                .OnDelete(DeleteBehavior.NoAction);  // Aturan ini juga bisa ditambahkan jika diperlukan

            modelBuilder.Entity<OrderFarmasi>()
                .HasOne(o => o.Kunjungan)
                .WithMany()
                .HasForeignKey(o => o.KunjunganId)
                .OnDelete(DeleteBehavior.Restrict);  // Atur ON DELETE NO ACTION di sini

            modelBuilder.Entity<OrderFarmasi>()
                .HasOne(o => o.Pasien)
                .WithMany()
                .HasForeignKey(o => o.PasienId)
                .OnDelete(DeleteBehavior.Restrict);  // Atur ON DELETE NO ACTION untuk Pasien

            modelBuilder.Entity<DetailOrderFarmasi>()
                .HasOne(d => d.OrderFarmasi)
                .WithMany()  // jika 1 order farmasi bisa memiliki banyak detail
                .HasForeignKey(d => d.OrderFarmasiId)
                .OnDelete(DeleteBehavior.Restrict);  // Hindari cascade delete jika diperlukan

            modelBuilder.Entity<DetailOrderFarmasi>()
                .HasOne(d => d.Barang)
                .WithMany()
                .HasForeignKey(d => d.BarangId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kunjungan>()
                .HasOne(k => k.Pasien)
                .WithMany()
                .HasForeignKey(k => k.PasienId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OpenEMR.Models.Tindakan> Tindakan { get; set; }

        public DbSet<OpenEMR.Models.OrderLab> OrderLab { get; set; }

        public DbSet<OpenEMR.Models.DetailOrderLab> DetailOrderLab { get; set; }

        public DbSet<OpenEMR.Models.OrderFarmasi> OrderFarmasi { get; set; }

        public DbSet<OpenEMR.Models.DetailOrderFarmasi> DetailOrderFarmasi { get; set; }

        public DbSet<OpenEMR.Models.Kunjungan> Kunjungan { get; set; }
    }
}
