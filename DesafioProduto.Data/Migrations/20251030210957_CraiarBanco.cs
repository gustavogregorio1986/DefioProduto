using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioProduto.Data.Migrations
{
    /// <inheritdoc />
    public partial class CraiarBanco : Migration
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
                    Preco = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    PrecoComDesconto = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: true),
                    QuantidadeProduto = table.Column<int>(type: "INT", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    LocalCompra = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Situacao = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[Preco] * [QuantidadeProduto]", stored: true),
                    Visualizacoes = table.Column<int>(type: "INT", nullable: false),
                    UltimaVisualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Favorito = table.Column<bool>(type: "BIT", nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
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
