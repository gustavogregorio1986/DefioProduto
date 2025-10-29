using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaVisualizacao",
                table: "tb_Produto",
                type: "DATETIME",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaVisualizacao",
                table: "tb_Produto",
                type: "datetime2",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldMaxLength: 10);
        }
    }
}
