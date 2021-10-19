using Microsoft.EntityFrameworkCore.Migrations;

namespace ScanApp.dbNet.Migrations
{
    public partial class ScanInfoUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "exSinceLastScan",
                table: "ScanInfos",
                newName: "ExSinceLastScan");

            migrationBuilder.RenameColumn(
                name: "exLast24H",
                table: "ScanInfos",
                newName: "ExLast24H");

            migrationBuilder.RenameColumn(
                name: "lastScan",
                table: "ScanInfos",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExSinceLastScan",
                table: "ScanInfos",
                newName: "exSinceLastScan");

            migrationBuilder.RenameColumn(
                name: "ExLast24H",
                table: "ScanInfos",
                newName: "exLast24H");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ScanInfos",
                newName: "lastScan");
        }
    }
}
