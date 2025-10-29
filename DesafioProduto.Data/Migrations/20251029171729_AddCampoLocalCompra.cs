using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoLocalCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalCompra",
                table: "tb_Produto",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalCompra",
                table: "tb_Produto");
        }
    }
}
