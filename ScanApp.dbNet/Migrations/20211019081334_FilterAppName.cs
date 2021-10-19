using Microsoft.EntityFrameworkCore.Migrations;

namespace ScanApp.dbNet.Migrations
{
    public partial class FilterAppName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "Filters",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "appID",
                table: "Filters",
                newName: "AppId");

            migrationBuilder.AddColumn<string>(
                name: "AppName",
                table: "Filters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppName",
                table: "Filters");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Filters",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "Filters",
                newName: "appID");
        }
    }
}
