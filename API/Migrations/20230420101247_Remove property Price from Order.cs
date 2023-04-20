using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RemovepropertyPricefromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice_Currency",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitPrice_Value",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitPrice_Currency",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice_Value",
                table: "Orders",
                type: "numeric",
                nullable: true);
        }
    }
}
