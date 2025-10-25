using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(10,2)", maxLength: 11, nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", maxLength: 10, nullable: false),
                    Situacao = table.Column<string>(type: "NVARCHAR(40)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Preco] * [QuantidadeProduto]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Produto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Produto");
        }
    }
}
