using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuenta.API.Migrations
{
    public partial class Deportista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PesoDeportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Intentos = table.Column<short>(type: "smallint", nullable: false),
                    DeportistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesoDeportistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesoDeportistas_Deportistas_DeportistaId",
                        column: x => x.DeportistaId,
                        principalTable: "Deportistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PesoDeportistas_DeportistaId",
                table: "PesoDeportistas",
                column: "DeportistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PesoDeportistas");

            migrationBuilder.DropTable(
                name: "Deportistas");
        }
    }
}
