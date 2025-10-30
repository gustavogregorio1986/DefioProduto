using AutoMapper;
using DesafioProduto.Data.Context;
using DesafioProduto.Data.DTO;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Dominio.Enum;
using DesafioProduto.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;




        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        private void AplicarDesconto(Produto produto, bool temDesconto)
        {
            produto.PrecoComDesconto = temDesconto ? produto.Preco * 0.9m : null;
        }

        public async Task<Produto> AdicionarProduto(Produto produto, bool temDesconto)
        {
            AplicarDesconto(produto, temDesconto);
            return await _produtoRepository.AdicionarProduto(produto);
        }

        public async Task<bool> AtualizarProdutoAsync(ProdutoDTO dto)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(dto.Id);
            if (produto == null)
                return false;

            // Atualiza os campos
            produto.NomeProduto = dto.NomeProduto;
            produto.Preco = dto.Preco;
            produto.QuantidadeProduto = dto.QuantidadeProduto;
            produto.Descricao = dto.Descricao;
            produto.LocalCompra = dto.LocalCompra;
            produto.Situacao = dto.Situacao;

            await _produtoRepository.AtualizarAsync(produto);
            return true;


        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id);
            if (produto == null)
                return false;

            await _produtoRepository.RemoverAsync(produto);
            return true;


        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarNoShoppingAsync(int page, int pageSize)
        {
            var (produtos, totalItems) = await _produtoRepository.ListarNoShoppingAsync(page, pageSize);

            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarAndamentoAsync(int page, int pageSize)
        {
            // Chama o repositório que já filtra por Situacao.Inativo
            var (produtos, totalItems) = await _produtoRepository.ListarAndamentoPaginadoAsync(page, pageSize);

            // Mapeia os produtos para DTOs
            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            // Retorna o resultado paginado
            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarAtivosAsync(int page, int pageSize)
        {
            // Chama o repositório que já filtra por Situacao.Inativo
            var (produtos, totalItems) = await _produtoRepository.ListarAtivosPaginadoAsync(page, pageSize);

            // Mapeia os produtos para DTOs
            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            // Retorna o resultado paginado
            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarConcluidoAsync(int page, int pageSize)
        {
            // Chama o repositório que já filtra por Situacao.Inativo
            var (produtos, totalItems) = await _produtoRepository.ListarConcluidoPaginadoAsync(page, pageSize);

            // Mapeia os produtos para DTOs
            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            // Retorna o resultado paginado
            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarInativosAsync(int page, int pageSize)
        {
            // Chama o repositório que já filtra por Situacao.Inativo
            var (produtos, totalItems) = await _produtoRepository.ListarInativosPaginadoAsync(page, pageSize);

            // Mapeia os produtos para DTOs
            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            // Retorna o resultado paginado
            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarPaginadoAsync(ProdutoFiltroDTO filtro)
        {
            var (produtos, totalItems) = await _produtoRepository.ListarPaginadoAsync(filtro.Page, filtro.PageSize, filtro.Nome);

            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / filtro.PageSize),
                Items = dtoList
            };

            
        }

        public async Task<PaginacaoResultadoDTO<ProdutoDTO>> ListarPendenteAsync(int page, int pageSize)
        {
            // Chama o repositório que já filtra por Situacao.Inativo
            var (produtos, totalItems) = await _produtoRepository.ListarPendentePaginadoAsync(page, pageSize);

            // Mapeia os produtos para DTOs
            var dtoList = _mapper.Map<List<ProdutoDTO>>(produtos);

            // Retorna o resultado paginado
            return new PaginacaoResultadoDTO<ProdutoDTO>
            {
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                Items = dtoList
            };
        }

        public async Task<ProdutoDTO?> VisualizarProdutoAsync(int id)
        {
            var produto = await _produtoRepository.BuscarPorIdAsync(id); // entidade Produto

            if (produto is null)
                return null;

            produto.RegistrarVisualizacao(); // método da entidade
            await _produtoRepository.AtualizarAsync(produto); // salva no banco

            return new ProdutoDTO
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                Preco = produto.Preco,
                PrecoComDesconto = produto.PrecoComDesconto,
                QuantidadeProduto = produto.QuantidadeProduto,
                Descricao = produto.Descricao,
                LocalCompra = produto.LocalCompra,
                Visualizacoes = produto.Visualizacoes,
                UltimaVisualizacao = produto.UltimaVisualizacao
            };

        }

        public async Task<Produto?> BuscarPorIdAsync(int id)
        {
           return await _produtoRepository.BuscarPorIdAsync(id);
        }
    }
}
