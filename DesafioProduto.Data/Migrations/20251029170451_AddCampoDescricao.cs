using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoDescricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "tb_Produto",
                type: "NVARCHAR(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "tb_Produto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)");
        }
    }
}
