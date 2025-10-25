using DesafioProduto.Data.Map;
using DesafioProduto.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.Context
{
    public class DesafioProdutoContext : DbContext
    {
        public DesafioProdutoContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
