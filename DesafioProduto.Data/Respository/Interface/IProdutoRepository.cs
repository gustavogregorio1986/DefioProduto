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

        Task<(List<Produto>, int)> ListarInativosPaginadoAsync(int page, int pageSize);

        Task<(List<Produto>, int)> ListarAtivosPaginadoAsync(int page, int pageSize);

        Task<(List<Produto>, int)> ListarAndamentoPaginadoAsync(int page, int pageSize);

        Task<(List<Produto>, int)> ListarPendentePaginadoAsync(int page, int pageSize);

        Task<(List<Produto>, int)> ListarConcluidoPaginadoAsync(int page, int pageSize);

        Task<Produto?> BuscarPorIdAsync(int id);
        Task AtualizarAsync(Produto produto);

        Task RemoverAsync(Produto produto);

        Task<(List<Produto>, int)> ListarNoShoppingAsync(int page, int pageSize);
    }

}
