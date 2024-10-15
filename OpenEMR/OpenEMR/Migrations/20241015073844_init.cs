using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEMR.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barang",
                columns: table => new
                {
                    KodeBarang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NamaBarang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeskripsiBarang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriBarang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatuanUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    HargaJual = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barang", x => x.KodeBarang);
                });

            migrationBuilder.CreateTable(
                name: "Pasien",
                columns: table => new
                {
                    NomorRekamMedis = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    NamaLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIK = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NomorIdentitasLain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaIbuKandung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JenisKelamin = table.Column<int>(type: "int", nullable: false),
                    Agama = table.Column<int>(type: "int", nullable: false),
                    Suku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BahasaYangDikuasai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatLengkap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RW = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    KelurahanDesa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KotaKabupaten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Negara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTDomisili = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RWDomisili = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    KelurahanDesaDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KotaKabupatenDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePosDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinsiDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NegaraDomisili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponRumah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponSelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pendidikan = table.Column<int>(type: "int", nullable: false),
                    Pekerjaan = table.Column<int>(type: "int", nullable: false),
                    StatusPernikahan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasien", x => x.NomorRekamMedis);
                });

            migrationBuilder.CreateTable(
                name: "Pemeriksaan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeTarif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisPemeriksaan = table.Column<int>(type: "int", nullable: false),
                    KategoriPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarif = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pemeriksaan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Penjamin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPenjamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPasien = table.Column<int>(type: "int", nullable: false),
                    TarifJasaAdministrasi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TarifRumahSakit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penjamin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPoli = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelamin = table.Column<int>(type: "int", nullable: false),
                    AlamatRumah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponPribadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTeleponDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatEmailPribadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPernikahan = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomorSIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaripPemeriksaan = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PoliId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pegawai_Poli_PoliId",
                        column: x => x.PoliId,
                        principalTable: "Poli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kunjungan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DokterId = table.Column<int>(type: "int", nullable: false),
                    StatusPasien = table.Column<int>(type: "int", nullable: false),
                    WaktuMendaftar = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PenjaminId = table.Column<int>(type: "int", nullable: false),
                    NomorRegis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunjungan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kunjungan_Pasien_PasienId",
                        column: x => x.PasienId,
                        principalTable: "Pasien",
                        principalColumn: "NomorRekamMedis",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kunjungan_Pegawai_DokterId",
                        column: x => x.DokterId,
                        principalTable: "Pegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kunjungan_Penjamin_PenjaminId",
                        column: x => x.PenjaminId,
                        principalTable: "Penjamin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderFarmasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PegawaiId = table.Column<int>(type: "int", nullable: false),
                    KunjunganId = table.Column<int>(type: "int", nullable: false),
                    PasienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WaktuPermintaanOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomorPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFarmasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFarmasi_Kunjungan_KunjunganId",
                        column: x => x.KunjunganId,
                        principalTable: "Kunjungan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFarmasi_Pasien_PasienId",
                        column: x => x.PasienId,
                        principalTable: "Pasien",
                        principalColumn: "NomorRekamMedis",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderFarmasi_Pegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "Pegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PegawaiId = table.Column<int>(type: "int", nullable: false),
                    WaktuPermintaanOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomorPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KunjunganId = table.Column<int>(type: "int", nullable: false),
                    NomorOrderLab = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLab_Kunjungan_KunjunganId",
                        column: x => x.KunjunganId,
                        principalTable: "Kunjungan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLab_Pegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "Pegawai",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tindakan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PegawaiId = table.Column<int>(type: "int", nullable: false),
                    KunjunganId = table.Column<int>(type: "int", nullable: false),
                    PemeriksaanId = table.Column<int>(type: "int", nullable: false),
                    WaktuPemeriksaan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tindakan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tindakan_Kunjungan_KunjunganId",
                        column: x => x.KunjunganId,
                        principalTable: "Kunjungan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tindakan_Pegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "Pegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tindakan_Pemeriksaan_PemeriksaanId",
                        column: x => x.PemeriksaanId,
                        principalTable: "Pemeriksaan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailOrderFarmasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFarmasiId = table.Column<int>(type: "int", nullable: false),
                    BarangId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Jumlah = table.Column<int>(type: "int", nullable: false),
                    AturanPakai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrderFarmasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailOrderFarmasi_Barang_BarangId",
                        column: x => x.BarangId,
                        principalTable: "Barang",
                        principalColumn: "KodeBarang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailOrderFarmasi_OrderFarmasi_OrderFarmasiId",
                        column: x => x.OrderFarmasiId,
                        principalTable: "OrderFarmasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailOrderLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PegawaiId = table.Column<int>(type: "int", nullable: false),
                    PemeriksaanId = table.Column<int>(type: "int", nullable: false),
                    WaktuDilakukanPemeriksaan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NilaiMinimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NilaiMaksimal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasilPemeriksaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderLabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrderLab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailOrderLab_OrderLab_OrderLabId",
                        column: x => x.OrderLabId,
                        principalTable: "OrderLab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOrderLab_Pegawai_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "Pegawai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOrderLab_Pemeriksaan_PemeriksaanId",
                        column: x => x.PemeriksaanId,
                        principalTable: "Pemeriksaan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrderFarmasi_BarangId",
                table: "DetailOrderFarmasi",
                column: "BarangId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrderFarmasi_OrderFarmasiId",
                table: "DetailOrderFarmasi",
                column: "OrderFarmasiId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrderLab_OrderLabId",
                table: "DetailOrderLab",
                column: "OrderLabId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrderLab_PegawaiId",
                table: "DetailOrderLab",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrderLab_PemeriksaanId",
                table: "DetailOrderLab",
                column: "PemeriksaanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunjungan_DokterId",
                table: "Kunjungan",
                column: "DokterId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunjungan_PasienId",
                table: "Kunjungan",
                column: "PasienId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunjungan_PenjaminId",
                table: "Kunjungan",
                column: "PenjaminId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFarmasi_KunjunganId",
                table: "OrderFarmasi",
                column: "KunjunganId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFarmasi_PasienId",
                table: "OrderFarmasi",
                column: "PasienId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFarmasi_PegawaiId",
                table: "OrderFarmasi",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLab_KunjunganId",
                table: "OrderLab",
                column: "KunjunganId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLab_PegawaiId",
                table: "OrderLab",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_PoliId",
                table: "Pegawai",
                column: "PoliId");

            migrationBuilder.CreateIndex(
                name: "IX_Tindakan_KunjunganId",
                table: "Tindakan",
                column: "KunjunganId");

            migrationBuilder.CreateIndex(
                name: "IX_Tindakan_PegawaiId",
                table: "Tindakan",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Tindakan_PemeriksaanId",
                table: "Tindakan",
                column: "PemeriksaanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOrderFarmasi");

            migrationBuilder.DropTable(
                name: "DetailOrderLab");

            migrationBuilder.DropTable(
                name: "Tindakan");

            migrationBuilder.DropTable(
                name: "Barang");

            migrationBuilder.DropTable(
                name: "OrderFarmasi");

            migrationBuilder.DropTable(
                name: "OrderLab");

            migrationBuilder.DropTable(
                name: "Pemeriksaan");

            migrationBuilder.DropTable(
                name: "Kunjungan");

            migrationBuilder.DropTable(
                name: "Pasien");

            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "Penjamin");

            migrationBuilder.DropTable(
                name: "Poli");
        }
    }
}
