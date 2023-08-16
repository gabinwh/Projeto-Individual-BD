using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabPraticoBDIndividual.Migrations
{
    /// <inheritdoc />
    public partial class AjeitaCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "cpf",
                table: "Usuarios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cpf",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
