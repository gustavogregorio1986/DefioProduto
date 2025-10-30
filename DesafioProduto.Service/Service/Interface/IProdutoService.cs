using DesafioProduto.Data.DTO;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Service.Service.Interface
{
    public interface IProdutoService
    {
        Task<Produto> AdicionarProduto(Produto produto, bool temDesconto);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarPaginadoAsync(ProdutoFiltroDTO filtro);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarInativosAsync(int page, int pageSize);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarAtivosAsync(int page, int pageSize);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarAndamentoAsync(int page, int pageSize);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarPendenteAsync(int page, int pageSize);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarConcluidoAsync(int page, int pageSize);

        Task<bool> AtualizarProdutoAsync(ProdutoDTO dto);

        Task<bool> ExcluirAsync(int id);

        Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarNoShoppingAsync(int page, int pageSize);

        Task<ProdutoDTO?> VisualizarProdutoAsync(int id);

        Task<Produto?> BuscarPorIdAsync(int id);
    }
}
