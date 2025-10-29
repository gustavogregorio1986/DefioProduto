using DesafioProduto.Data.Context;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
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
    }
}
