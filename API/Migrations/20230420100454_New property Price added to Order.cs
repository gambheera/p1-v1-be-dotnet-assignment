using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewpropertyPriceaddedtoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitPrice_Currency",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice_Value",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice_Currency",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitPrice_Value",
                table: "Orders");
        }
    }
}
