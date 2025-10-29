using DesafioProduto.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Data.DTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        public string? NomeProduto { get; set; }

        public Decimal Preco { get; set; }

        public int QuantidadeProduto { get; set; }

        public DateTime DataCadastro { get; set; }

        public Situacao Situacao { get; set; }

        public decimal Total { get; set; }
    }
}
