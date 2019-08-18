using Microsoft.EntityFrameworkCore.Migrations;

namespace Inmobiliaria.Migrations
{
    public partial class Precio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "Inmueble",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Inmueble",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
