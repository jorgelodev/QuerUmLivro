using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuerUmLivro.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUsuarioLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Livro_DoadorId",
                table: "Livro",
                column: "DoadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Usuario_DoadorId",
                table: "Livro",
                column: "DoadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Usuario_DoadorId",
                table: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Livro_DoadorId",
                table: "Livro");
        }
    }
}
