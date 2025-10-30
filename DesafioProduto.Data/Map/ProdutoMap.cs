using DesafioProduto.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeProduto)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");

            builder.Property(p => p.Categoria)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.PrecoComDesconto)
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            builder.Property(p => p.LocalCompra)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");

            builder.Property(p => p.QuantidadeProduto)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.Favorito)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(p => p.UltimaVisualizacao)
                .HasColumnType("DATETIME");

            builder.Property(p => p.Visualizacoes)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(p => p.Situacao)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("NVARCHAR(40)");

            builder.Property(p => p.Total)
                .HasComputedColumnSql("[Preco] * [QuantidadeProduto]", stored: true);

        }
    }
}
