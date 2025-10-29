using AutoMapper;
using DesafioProduto.Data.DTO;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Dominio.Enum;
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
        private readonly IMapper _mapper;



        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            return await _produtoRepository.AdicionarProduto(produto);
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
    }
}
