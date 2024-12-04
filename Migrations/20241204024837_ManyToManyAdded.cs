using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Videojuego.Migrations
{
    public partial class ManyToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Empresa_EmpresaId",
                table: "Juegos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "Empresas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Desarrolladoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Juegos_Desarrolladoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJuegos = table.Column<int>(type: "int", nullable: false),
                    IdDesarrolladora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos_Desarrolladoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Juegos_Desarrolladoras_Desarrolladoras_IdDesarrolladora",
                        column: x => x.IdDesarrolladora,
                        principalTable: "Desarrolladoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Juegos_Desarrolladoras_Juegos_IdJuegos",
                        column: x => x.IdJuegos,
                        principalTable: "Juegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_Desarrolladoras_IdDesarrolladora",
                table: "Juegos_Desarrolladoras",
                column: "IdDesarrolladora");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_Desarrolladoras_IdJuegos",
                table: "Juegos_Desarrolladoras",
                column: "IdJuegos");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Empresas_EmpresaId",
                table: "Juegos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Empresas_EmpresaId",
                table: "Juegos");

            migrationBuilder.DropTable(
                name: "Juegos_Desarrolladoras");

            migrationBuilder.DropTable(
                name: "Desarrolladoras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "Empresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Empresa_EmpresaId",
                table: "Juegos",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
