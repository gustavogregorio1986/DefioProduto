using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.DTO
{
    public class PaginacaoResultadoDTO<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }
}
