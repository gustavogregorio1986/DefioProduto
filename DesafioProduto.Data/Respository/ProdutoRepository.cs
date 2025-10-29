using DesafioProduto.Data.Context;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.Respository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DesafioProdutoContext _context;

        public ProdutoRepository(DesafioProdutoContext context)
        {
            _context = context;
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<(List<Produto>, int)> ListarPaginadoAsync(int page, int pageSize, string? nome)
        {
            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(p => p.NomeProduto.Contains(nome));

            var totalItems = await query.CountAsync();
            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);
        }
    }
}
