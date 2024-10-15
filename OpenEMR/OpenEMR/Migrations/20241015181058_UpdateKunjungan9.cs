using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEMR.Migrations
{
    public partial class UpdateKunjungan9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anus",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bibir",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dada",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DenyutJantung",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genital",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GigiGeligi",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hidung",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JariKaki",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JariTangan",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kepala",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KukuKaki",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KukuTangan",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LangitLangit",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Leher",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LenganAtas",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LenganBawah",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lidah",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mata",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payudara",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pernapasan",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersendianKaki",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersendianTangan",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Perut",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Punggung",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rambut",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SuhuTubuh",
                table: "Kunjungan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TekananDarahDiastole",
                table: "Kunjungan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TekananDarahSistole",
                table: "Kunjungan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telinga",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tenggorokan",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tonsil",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TungkaiAtas",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TungkaiBawah",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anus",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Bibir",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Dada",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "DenyutJantung",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Genital",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "GigiGeligi",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Hidung",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "JariKaki",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "JariTangan",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Kepala",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "KukuKaki",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "KukuTangan",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "LangitLangit",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Leher",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "LenganAtas",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "LenganBawah",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Lidah",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Mata",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Payudara",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Pernapasan",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "PersendianKaki",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "PersendianTangan",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Perut",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Punggung",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Rambut",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "SuhuTubuh",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "TekananDarahDiastole",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "TekananDarahSistole",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Telinga",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Tenggorokan",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "Tonsil",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "TungkaiAtas",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "TungkaiBawah",
                table: "Kunjungan");
        }
    }
}
