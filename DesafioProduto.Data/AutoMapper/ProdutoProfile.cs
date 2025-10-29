using AutoMapper;
using DesafioProduto.Data.DTO;
using DesafioProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<ProdutoDTO, Produto>();
        }
    }
}
