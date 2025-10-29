using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            return await _produtoRepository.AdicionarProduto(produto);
        }
    }
}
