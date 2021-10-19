using Microsoft.EntityFrameworkCore.Migrations;

namespace ScanApp.dbNet.Migrations
{
    public partial class FilterRemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppId",
                table: "Filters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "Filters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
