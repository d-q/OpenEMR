using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEMR.Migrations
{
    public partial class UpdateKunjungan8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdaNyeri",
                table: "Kunjungan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DurasiNyeri",
                table: "Kunjungan",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrekuensiNyeri",
                table: "Kunjungan",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LokasiNyeri",
                table: "Kunjungan",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetodeNyeri",
                table: "Kunjungan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenyebabNyeri",
                table: "Kunjungan",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkalaNyeri",
                table: "Kunjungan",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdaNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "DurasiNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "FrekuensiNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "LokasiNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "MetodeNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "PenyebabNyeri",
                table: "Kunjungan");

            migrationBuilder.DropColumn(
                name: "SkalaNyeri",
                table: "Kunjungan");
        }
    }
}
