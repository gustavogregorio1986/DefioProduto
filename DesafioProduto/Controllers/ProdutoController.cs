using AutoMapper;
using DesafioProduto.Data.DTO;
using DesafioProduto.Data.Respository.Interface;
using DesafioProduto.Dominio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        [Route("AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoDto);
                var resultado = await _produtoRepository.AdicionarProduto(produto);
                var resultadoDto = _mapper.Map<ProdutoDTO>(resultado);
                return Ok(resultadoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
