using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuerUmLivro.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUsuarioInteresse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Interesse_InteressadoId",
                table: "Interesse",
                column: "InteressadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interesse_Usuario_InteressadoId",
                table: "Interesse",
                column: "InteressadoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interesse_Usuario_InteressadoId",
                table: "Interesse");

            migrationBuilder.DropIndex(
                name: "IX_Interesse_InteressadoId",
                table: "Interesse");
        }
    }
}
