﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenEMR.Data;

namespace OpenEMR.Migrations
{
    [DbContext(typeof(OpenEMRContext))]
    partial class OpenEMRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenEMR.Models.Barang", b =>
                {
                    b.Property<string>("KodeBarang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeskripsiBarang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HargaJual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("KategoriBarang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaBarang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SatuanUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("KodeBarang");

                    b.ToTable("Barang");
                });

            modelBuilder.Entity("OpenEMR.Models.DetailOrderFarmasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AturanPakai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarangId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Jumlah")
                        .HasColumnType("int");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderFarmasiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BarangId");

                    b.HasIndex("OrderFarmasiId");

                    b.ToTable("DetailOrderFarmasi");
                });

            modelBuilder.Entity("OpenEMR.Models.DetailOrderLab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HasilPemeriksaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NilaiMaksimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NilaiMinimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderLabId")
                        .HasColumnType("int");

                    b.Property<int>("PegawaiId")
                        .HasColumnType("int");

                    b.Property<int>("PemeriksaanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WaktuDilakukanPemeriksaan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderLabId");

                    b.HasIndex("PegawaiId");

                    b.HasIndex("PemeriksaanId");

                    b.ToTable("DetailOrderLab");
                });

            modelBuilder.Entity("OpenEMR.Models.Kunjungan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdaNyeri")
                        .HasColumnType("bit");

                    b.Property<string>("Anus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bibir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DenyutJantung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DokterId")
                        .HasColumnType("int");

                    b.Property<string>("DurasiNyeri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FrekuensiNyeri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Genital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GigiGeligi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hidung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JariKaki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JariTangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kepala")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KukuKaki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KukuTangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LangitLangit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Leher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LenganAtas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LenganBawah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lidah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LokasiNyeri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Mata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetodeNyeri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorRegis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasienId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Payudara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PenjaminId")
                        .HasColumnType("int");

                    b.Property<string>("PenyebabNyeri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Pernapasan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersendianKaki")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersendianTangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Punggung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rambut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkalaNyeri")
                        .HasColumnType("int");

                    b.Property<int>("StatusPasien")
                        .HasColumnType("int");

                    b.Property<float>("SuhuTubuh")
                        .HasColumnType("real");

                    b.Property<int>("TekananDarahDiastole")
                        .HasColumnType("int");

                    b.Property<int>("TekananDarahSistole")
                        .HasColumnType("int");

                    b.Property<string>("Telinga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenggorokan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tonsil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TungkaiAtas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TungkaiBawah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WaktuMendaftar")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DokterId");

                    b.HasIndex("PasienId");

                    b.HasIndex("PenjaminId");

                    b.ToTable("Kunjungan");
                });

            modelBuilder.Entity("OpenEMR.Models.OrderFarmasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KunjunganId")
                        .HasColumnType("int");

                    b.Property<string>("NomorPemeriksaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasienId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PegawaiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WaktuPermintaanOrder")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KunjunganId");

                    b.HasIndex("PasienId");

                    b.HasIndex("PegawaiId");

                    b.ToTable("OrderFarmasi");
                });

            modelBuilder.Entity("OpenEMR.Models.OrderLab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KunjunganId")
                        .HasColumnType("int");

                    b.Property<string>("NomorOrderLab")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorPemeriksaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PegawaiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WaktuPermintaanOrder")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KunjunganId");

                    b.HasIndex("PegawaiId");

                    b.ToTable("OrderLab");
                });

            modelBuilder.Entity("OpenEMR.Models.Pasien", b =>
                {
                    b.Property<string>("NomorRekamMedis")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Agama")
                        .HasColumnType("int");

                    b.Property<string>("AlamatDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatLengkap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BahasaYangDikuasai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("JenisKelamin")
                        .HasColumnType("int");

                    b.Property<string>("Kecamatan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KecamatanDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KelurahanDesa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KelurahanDesaDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodePosDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KotaKabupaten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KotaKabupatenDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("NamaIbuKandung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaLengkap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Negara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NegaraDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorIdentitasLain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponRumah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponSelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pekerjaan")
                        .HasColumnType("int");

                    b.Property<int>("Pendidikan")
                        .HasColumnType("int");

                    b.Property<string>("Provinsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinsiDomisili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RT")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RTDomisili")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RW")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("RWDomisili")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("StatusPernikahan")
                        .HasColumnType("int");

                    b.Property<string>("Suku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TanggalLahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NomorRekamMedis");

                    b.ToTable("Pasien");
                });

            modelBuilder.Entity("OpenEMR.Models.Pegawai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlamatEmailPribadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlamatRumah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JenisKelamin")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponDarurat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomorTeleponPribadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusPernikahan")
                        .HasColumnType("int");

                    b.Property<DateTime>("TanggalLahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("TempatLahir")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pegawai");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pegawai");
                });

            modelBuilder.Entity("OpenEMR.Models.Pemeriksaan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JenisPemeriksaan")
                        .HasColumnType("int");

                    b.Property<string>("KategoriPemeriksaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodeTarif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaPemeriksaan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tarif")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pemeriksaan");
                });

            modelBuilder.Entity("OpenEMR.Models.Penjamin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamaPenjamin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusPasien")
                        .HasColumnType("int");

                    b.Property<decimal>("TarifJasaAdministrasi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TarifRumahSakit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Penjamin");
                });

            modelBuilder.Entity("OpenEMR.Models.Poli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamaPoli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Poli");
                });

            modelBuilder.Entity("OpenEMR.Models.Tindakan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KunjunganId")
                        .HasColumnType("int");

                    b.Property<int?>("KunjunganId1")
                        .HasColumnType("int");

                    b.Property<int>("PegawaiId")
                        .HasColumnType("int");

                    b.Property<int>("PemeriksaanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WaktuPemeriksaan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KunjunganId");

                    b.HasIndex("KunjunganId1");

                    b.HasIndex("PegawaiId");

                    b.HasIndex("PemeriksaanId");

                    b.ToTable("Tindakan");
                });

            modelBuilder.Entity("OpenEMR.Models.Dokter", b =>
                {
                    b.HasBaseType("OpenEMR.Models.Pegawai");

                    b.Property<string>("NomorSIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliId")
                        .HasColumnType("int");

                    b.Property<decimal>("TaripPemeriksaan")
                        .HasColumnType("decimal(18,2)");

                    b.HasIndex("PoliId");

                    b.HasDiscriminator().HasValue("Dokter");
                });

            modelBuilder.Entity("OpenEMR.Models.DetailOrderFarmasi", b =>
                {
                    b.HasOne("OpenEMR.Models.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("BarangId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.OrderFarmasi", "OrderFarmasi")
                        .WithMany()
                        .HasForeignKey("OrderFarmasiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("OrderFarmasi");
                });

            modelBuilder.Entity("OpenEMR.Models.DetailOrderLab", b =>
                {
                    b.HasOne("OpenEMR.Models.OrderLab", "OrderLab")
                        .WithMany()
                        .HasForeignKey("OrderLabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pegawai", "Pemeriksa")
                        .WithMany()
                        .HasForeignKey("PegawaiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pemeriksaan", "Pemeriksaan")
                        .WithMany()
                        .HasForeignKey("PemeriksaanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderLab");

                    b.Navigation("Pemeriksa");

                    b.Navigation("Pemeriksaan");
                });

            modelBuilder.Entity("OpenEMR.Models.Kunjungan", b =>
                {
                    b.HasOne("OpenEMR.Models.Dokter", "Dokter")
                        .WithMany()
                        .HasForeignKey("DokterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pasien", "Pasien")
                        .WithMany()
                        .HasForeignKey("PasienId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Penjamin", "Penjamin")
                        .WithMany()
                        .HasForeignKey("PenjaminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dokter");

                    b.Navigation("Pasien");

                    b.Navigation("Penjamin");
                });

            modelBuilder.Entity("OpenEMR.Models.OrderFarmasi", b =>
                {
                    b.HasOne("OpenEMR.Models.Kunjungan", "Kunjungan")
                        .WithMany()
                        .HasForeignKey("KunjunganId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pasien", "Pasien")
                        .WithMany()
                        .HasForeignKey("PasienId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pegawai", "Pegawai")
                        .WithMany()
                        .HasForeignKey("PegawaiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunjungan");

                    b.Navigation("Pasien");

                    b.Navigation("Pegawai");
                });

            modelBuilder.Entity("OpenEMR.Models.OrderLab", b =>
                {
                    b.HasOne("OpenEMR.Models.Kunjungan", "Kunjungan")
                        .WithMany()
                        .HasForeignKey("KunjunganId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pegawai", "Pemeriksa")
                        .WithMany()
                        .HasForeignKey("PegawaiId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kunjungan");

                    b.Navigation("Pemeriksa");
                });

            modelBuilder.Entity("OpenEMR.Models.Tindakan", b =>
                {
                    b.HasOne("OpenEMR.Models.Kunjungan", "Kunjungan")
                        .WithMany()
                        .HasForeignKey("KunjunganId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Kunjungan", null)
                        .WithMany("Tindakans")
                        .HasForeignKey("KunjunganId1");

                    b.HasOne("OpenEMR.Models.Pegawai", "Pemeriksa")
                        .WithMany()
                        .HasForeignKey("PegawaiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OpenEMR.Models.Pemeriksaan", "TindakanMedis")
                        .WithMany()
                        .HasForeignKey("PemeriksaanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunjungan");

                    b.Navigation("Pemeriksa");

                    b.Navigation("TindakanMedis");
                });

            modelBuilder.Entity("OpenEMR.Models.Dokter", b =>
                {
                    b.HasOne("OpenEMR.Models.Poli", "Poli")
                        .WithMany()
                        .HasForeignKey("PoliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poli");
                });

            modelBuilder.Entity("OpenEMR.Models.Kunjungan", b =>
                {
                    b.Navigation("Tindakans");
                });
#pragma warning restore 612, 618
        }
    }
}
