using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class ResultProdutoEvento
    {
        public int EventosIdEvento { get; set; }
        public int ProdutoIdProduto { get; set; }
        public int Quantidade { get; set; }
        public int IdEvento { get; set; }
        public string NomeEvento { get; set; }
        public string CategoriaProduto { get; set; }
    }
}
