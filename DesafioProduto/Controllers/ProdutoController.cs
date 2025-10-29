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
    }
}
