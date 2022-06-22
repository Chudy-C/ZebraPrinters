using Microsoft.EntityFrameworkCore.Migrations;

namespace ZebraPrinters.Migrations
{
    public partial class FixPrinterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Printers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Printers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Szczytno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Printers");
        }
    }
}
