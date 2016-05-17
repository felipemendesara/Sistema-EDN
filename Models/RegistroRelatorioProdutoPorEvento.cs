using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class RegistroRelatorioProdutoPorEvento
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public int QuantidadeProduto { get; set; }
    }
}
