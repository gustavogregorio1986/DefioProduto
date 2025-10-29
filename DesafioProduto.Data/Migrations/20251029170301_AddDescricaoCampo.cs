using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescricaoCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "tb_Produto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "tb_Produto");
        }
    }
}
