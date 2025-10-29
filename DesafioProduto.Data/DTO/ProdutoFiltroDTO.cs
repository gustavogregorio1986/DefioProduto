using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.DTO
{
    public class ProdutoFiltroDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Nome { get; set; }


    }
}
