using AutoMapper;
using DesafioProduto.Data.DTO;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using DesafioProduto.Service.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [HttpPost]
        [Route("AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoDto);
                var resultado = await _produtoService.AdicionarProduto(produto);
                var resultadoDto = _mapper.Map<ProdutoDTO>(resultado);
                return Ok(resultadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos([FromQuery] ProdutoFiltroDTO filtro)
        {
            var resultado = await _produtoService.ListarPaginadoAsync(filtro);
            return Ok(resultado);
        }

        [HttpGet("Inativos")]
        public async Task<IActionResult> ListarInativos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _produtoService.ListarInativosAsync(page, pageSize);
            return Ok(resultado);
        }

        [HttpGet("Ativos")]
        public async Task<IActionResult> ListarAtivos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _produtoService.ListarAtivosAsync(page, pageSize);
            return Ok(resultado);
        }

        [HttpGet("Pendente")]
        public async Task<IActionResult> ListarPendente([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _produtoService.ListarPendenteAsync(page, pageSize);
            return Ok(resultado);
        }

        [HttpGet("Concluido")]
        public async Task<IActionResult> ListarConcluido([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _produtoService.ListarConcluidoAsync(page, pageSize);
            return Ok(resultado);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL não bate com o corpo");

            var sucesso = await _produtoService.AtualizarProdutoAsync(dto);
            if (!sucesso)
                return NotFound("Produto não encontrado");

            return NoContent(); // ou Ok() se quiser retornar algo
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var sucesso = await _produtoService.ExcluirAsync(id);
            if (!sucesso)
                return NotFound("Produto não encontrado");

            return NoContent(); // ou Ok("Produto excluído com sucesso")
        }

        [HttpGet]
        [Route("ListarNoShopping")]
        public async Task<IActionResult> ListarNoShopping([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _produtoService.ListarNoShoppingAsync(page, pageSize);
            return Ok(resultado);
        }

        [HttpGet("{id}/visualizar")]
        public async Task<IActionResult> Visualizar(int id)
        {
            var produto = await _produtoService.VisualizarProdutoAsync(id);

            if (produto is null)
                return NotFound();

            produto.RegistrarVisualizacao();

            await _produtoService.AtualizarProdutoAsync(produto);

            return Ok(produto); // ou mapeie para um DTO se preferir
        }
    }
}
