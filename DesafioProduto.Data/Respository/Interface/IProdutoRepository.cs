using DesafioProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.Respository.Interface
{
    public interface IProdutoRepository
    {
        Task<Produto> AdicionarProduto(Produto produto);

        Task<(List<Produto>, int)> ListarPaginadoAsync(int page, int pageSize, string? nome);


    }
}
