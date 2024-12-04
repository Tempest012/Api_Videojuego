using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Videojuego.Migrations
{
    public partial class EmpresaAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Juegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_EmpresaId",
                table: "Juegos",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Juegos_Empresa_EmpresaId",
                table: "Juegos",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juegos_Empresa_EmpresaId",
                table: "Juegos");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Juegos_EmpresaId",
                table: "Juegos");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Juegos");
        }
    }
}
