using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class g1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tipo",
                newName: "TipoId");

            migrationBuilder.RenameColumn(
                name: "IdConta",
                table: "Registro",
                newName: "TipoId");

            migrationBuilder.AddColumn<int>(
                name: "RegistroId",
                table: "Registro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registro_TipoId",
                table: "Registro",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Registro_TipoId",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "RegistroId",
                table: "Registro");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "Tipo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoId",
                table: "Registro",
                newName: "IdConta");
        }
    }
}
