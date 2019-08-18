using Microsoft.EntityFrameworkCore.Migrations;

namespace Inmobiliaria.Migrations
{
    public partial class Operacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operacion",
                table: "Inmueble",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operacion",
                table: "Inmueble");
        }
    }
}
