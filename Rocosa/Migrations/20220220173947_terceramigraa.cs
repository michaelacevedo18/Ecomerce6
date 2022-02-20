using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rocosa.Migrations
{
    public partial class terceramigraa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Producto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Producto");
        }
    }
}
