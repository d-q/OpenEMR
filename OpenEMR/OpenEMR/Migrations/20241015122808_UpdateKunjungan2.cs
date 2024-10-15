using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEMR.Migrations
{
    public partial class UpdateKunjungan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KunjunganId1",
                table: "Tindakan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tindakan_KunjunganId1",
                table: "Tindakan",
                column: "KunjunganId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tindakan_Kunjungan_KunjunganId1",
                table: "Tindakan",
                column: "KunjunganId1",
                principalTable: "Kunjungan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tindakan_Kunjungan_KunjunganId1",
                table: "Tindakan");

            migrationBuilder.DropIndex(
                name: "IX_Tindakan_KunjunganId1",
                table: "Tindakan");

            migrationBuilder.DropColumn(
                name: "KunjunganId1",
                table: "Tindakan");
        }
    }
}
