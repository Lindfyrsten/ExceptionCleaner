using Microsoft.EntityFrameworkCore.Migrations;

namespace ScanApp.dbNet.Migrations
{
    public partial class SITotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExTotal",
                table: "ScanInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExTotal",
                table: "ScanInfos");
        }
    }
}
