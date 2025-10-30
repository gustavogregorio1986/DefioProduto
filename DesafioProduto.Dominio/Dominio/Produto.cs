using DesafioProduto.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Dominio.Dominio
{
    public class Produto
    {
        public int Id { get; set; }

        public string? NomeProduto { get; set; }

        public Decimal Preco { get; set; }

        public int QuantidadeProduto { get; set; }

        public string? Descricao { get; set; }

        public string? LocalCompra { get; set; }

        public DateTime DataCadastro { get; set; }

        public Situacao Situacao { get; set; }

        public decimal Total { get; set; }

        public int Visualizacoes { get; set; }

        public string UltimaVisualizacao { get; set; }


        public void RegistrarVisualizacao()
        {
            Visualizacoes++;
        }





    }
}
