using DesafioProduto.Data.Context;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Dominio.Enum;
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

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto?> BuscarPorIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);


        }

        public async Task<(List<Produto>, int)> ListarAndamentoPaginadoAsync(int page, int pageSize)
        {
            var query = _context.Produtos
             .Where(p => p.Situacao == Situacao.Andamemto); // ou outro valor que represente inatividade

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);
        }

        public async Task<(List<Produto>, int)> ListarAtivosPaginadoAsync(int page, int pageSize)
        {
            var query = _context.Produtos
             .Where(p => p.Situacao == Situacao.Ativo); // ou outro valor que represente inatividade

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);
        }

        public async Task<(List<Produto>, int)> ListarConcluidoPaginadoAsync(int page, int pageSize)
        {
            var query = _context.Produtos
             .Where(p => p.Situacao == Situacao.concluido); // ou outro valor que represente inatividade

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);
        }

        public async Task<(List<Produto>, int)> ListarInativosPaginadoAsync(int page, int pageSize)
        {
            var query = _context.Produtos
             .Where(p => p.Situacao == Situacao.Inativo); // ou outro valor que represente inatividade

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);

        }

        public async Task<(List<Produto>, int)> ListarNoShoppingAsync(int page, int pageSize)
        {
            var query = _context.Produtos
         .Where(p => p.LocalCompra.Contains( "Shopping")); // filtro por localização

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);


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

        public async Task<(List<Produto>, int)> ListarPendentePaginadoAsync(int page, int pageSize)
        {
            var query = _context.Produtos
             .Where(p => p.Situacao == Situacao.concluido); // ou outro valor que represente inatividade

            var totalItems = await query.CountAsync();

            var produtos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (produtos, totalItems);
        }

        public async Task RemoverAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
