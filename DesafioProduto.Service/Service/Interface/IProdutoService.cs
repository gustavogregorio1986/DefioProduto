using DesafioProduto.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioProduto.Service.Service.Interface
{
    public interface IProdutoService
    {
        Task<Produto> AdicionarProduto(Produto produto);
    }
}
