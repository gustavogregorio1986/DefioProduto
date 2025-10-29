using AutoMapper;
using DesafioProduto.Data.Respository.Interface;
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
    }
}
